using System.Collections.Immutable;
using System.Security.AccessControl;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using Random = System.Random;

public class SpawnTile : MonoBehaviour
{
    public GameObject[] tiles; // List of tile PREFabs to spawn from
    public GameObject player; // Player GameObject, used to track player movement on tiles
    public GameObject starterTile; //Base Tile GameObject PREFab
    public GameObject PRECoin; //Coin PREFab
    private GameObject _lastSpawnedTile = null, _prevSpawnedTile;
    private Vector3 _spawnNextTileAt = new Vector3(0,0,0); // Position of the next tile spawn location
    private Vector3 _coinPos = new Vector3(0, 0, 0);
    private Queue<GameObject> _renderedTiles = new Queue<GameObject>(); //Queue of the rendered tiles,
                                                                        //used to manage the simultaneous spawned tiles
                                                                        
    private List<GameObject> spawnCoin(Transform parent, float zPos, float yPos = 1f, int spawnOnLanes = 1) // spawnOnLanes - var spawn coins on multiple lanes
                                                                                                            // zPos should be at least the 1.0f after the tile start
    {
        List<GameObject> spawnedCoins = new List<GameObject>();
        float[] lanes = { -3.5f, 0f, 3.5f }; //Available X axis positions for the coin
        Random random = new Random();
        int lane = random.Next(0,lanes.Length-1);
        _coinPos.x = lanes[lane];
        for (int i = 0; i != 5; i++)
        {
            GameObject coin = Instantiate(PRECoin, _coinPos, PRECoin.transform.rotation);
            coin.transform.parent = parent;
            coin.transform.GetChild(0).tag = "coin"; //Set the PREFabs's child Coin GameObject Tag to coin
            spawnedCoins.Add(coin);
            _coinPos.z += 2.5f; // Spawn next coin at least 2.5f away from the previous
        }
        return spawnedCoins;
    } 
    private float GetObjectZSize(GameObject ob){
        Renderer objectRenderer = ob.GetComponentInChildren<Renderer>();
        if (objectRenderer == null)
            return 0f; 
        return objectRenderer.bounds.size.z;
    }
    private void DestoyOldTiles()
    {
        while (_renderedTiles.Count > 5)
            Destroy(_renderedTiles.Dequeue());
    }
    private void SpawnNextTile(GameObject tile, Vector3 pos){
        float zSize = GetObjectZSize(tile);
        if (zSize == 0f) { return; }
        _prevSpawnedTile = _lastSpawnedTile;
        _lastSpawnedTile = Instantiate(tile, _spawnNextTileAt,transform.rotation);
        _coinPos = _spawnNextTileAt;
        spawnCoin(_lastSpawnedTile.transform, _spawnNextTileAt.z);
        _renderedTiles.Enqueue(_lastSpawnedTile); //Append the last spawned tile to the end of the queue
        _spawnNextTileAt.z += zSize; //Set the coordinates for the next tile to be just next to the previous one
    }
    void Awake(){
        // Spawn the starter tile and a few others before the Game Starts
        SpawnNextTile(starterTile,_spawnNextTileAt);
        for (int i = 0; i!=2; i++)
        {
            SpawnNextTile(starterTile, _spawnNextTileAt); 
        } 
    }
    void Update()
    {
        DestoyOldTiles();
        if((int)player.transform.position.z == (int)_prevSpawnedTile.transform.position.z){
            Random random = new Random();
            int tileIndex = random.Next(0,tiles.Length-1);
            SpawnNextTile(tiles[tileIndex],_spawnNextTileAt);
        }
    }
}
