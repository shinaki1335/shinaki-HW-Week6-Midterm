using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsScore : MonoBehaviour
{
    // When the collider is triggered
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name.Contains("Player")) {         //if collider was activated by the player
            GameManager.instance.Score++;                       //add one to score
            Destroy(gameObject);                                //destroy this object
        }
    }
}
