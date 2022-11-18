using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public int coinsCollected = 0;
    private void OnCollisionEnter(Collision obj)
    {
        if (obj.collider.CompareTag("coin"))
        {
            coinsCollected++;
            Destroy(obj.collider.gameObject);
            Debug.Log("Collected a coin");
        }
        else
            Debug.Log("nothing");
    }
}
