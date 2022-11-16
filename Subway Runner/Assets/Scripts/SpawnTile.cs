using System.Collections.Immutable;
using System.Security.AccessControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class SpawnTile : MonoBehaviour
{
    public GameObject[] tiles;
    public GameObject player;
    public GameObject starterTile;
    private GameObject _lastSpawnedTile = null, _prevSpawnedTile;
    private Vector3 _spawnNextTileAt = new Vector3(0,0,0);
    private Queue<GameObject> _renderedTiles = new Queue<GameObject>();
    // private Quaternion tileRotation = new Quaternion(10f,0,0,1);
    // Update is called once per frame
    // Use Destroy Method to to despawn old tiles
    // TO DO: Detect on which tile is the Player
    // TO DO: Destroy old tiles when player has reached some location or some consecutive tile
    // TO DO: Spawn coins randomly
    
    private float GetObjectZSize(GameObject ob){
        Renderer objectRenderer = ob.GetComponentInChildren<Renderer>();
        if (objectRenderer == null)
            return 0f; 
        return objectRenderer.bounds.size.z;
    }

    private void DestoyOldTiles()
    {
        while (_renderedTiles.Count > 4)
            Destroy(_renderedTiles.Dequeue());
    }

    private void SpawnNextTile(GameObject tile, Vector3 pos){
        float zSize = GetObjectZSize(tile);
        if (zSize == 0f)
        {
            return;
        }
        _prevSpawnedTile = _lastSpawnedTile;
        _lastSpawnedTile = Instantiate(tile, _spawnNextTileAt,transform.rotation);
        _renderedTiles.Enqueue(_lastSpawnedTile);
        _spawnNextTileAt.z += zSize; //Set the coordinates for the next tile to be just next to the previous one
    }
    void Awake(){
        SpawnNextTile(starterTile,_spawnNextTileAt);
        for (int i = 0; i!=2; i++){
            SpawnNextTile(starterTile, _spawnNextTileAt);
        }
    }
    void Update()
    {
        DestoyOldTiles();
        // Debug.Log("Player: " + player.transform.position.z);
        // Debug.Log("PrevTile: " + prevSpawnedTile.transform.position.z);
        if((int)player.transform.position.z == (int)_prevSpawnedTile.transform.position.z){
            Random random = new Random();
            int tileIndex = random.Next(0,tiles.Length-1);
            SpawnNextTile(tiles[tileIndex],_spawnNextTileAt);
        }
    }
}
