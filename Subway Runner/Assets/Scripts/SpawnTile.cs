using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTile : MonoBehaviour
{
    public GameObject[] tiles;
    public GameObject player;
    public GameObject starterTile;
    private Vector3 spawnNextTileAt = new Vector3(0,0,0);
    // private Quaternion tileRotation = new Quaternion(10f,0,0,1);
    // Update is called once per frame
    // Use Destroy Method to to despawn old tiles
    // TO DO: Detect on which tile is the Player
    // TO DO: Destroy old tiles when player has reached some location or some consecutive tile
    // TO DO: Spawn coins randomly
    
    private void SpawnNextTile(GameObject tile, Vector3 pos){
        Instantiate(tile, spawnNextTileAt,transform.rotation);
        spawnNextTileAt.z += 18f;
    }
    void Awake(){
        SpawnNextTile(starterTile,spawnNextTileAt);
        for (int i = 0; i!=3; i++){
            SpawnNextTile(starterTile, spawnNextTileAt);
        }
    }
    void Update()
    {
        
    }
}
