using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{
    // When detecting a collision
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.name.Contains("Player")) {       //check if the other object is the player
            Destroy(gameObject);                              //destroy the object
            
            if (gameObject.name.Contains("Blue")) {           //if the object was the blueKey
                GameManager.instance.blueKey = true;          //set blueKey to true
            }
            else if (gameObject.name.Contains("Green")) {     //if the object was the greenKey
                GameManager.instance.greenKey = true;         //set greenKey to true
            }
            else if (gameObject.name.Contains("Red")) {       //if the object was the redKey
                GameManager.instance.redKey = true;           //set redKey to true
            }
            else if (gameObject.name.Contains("Yellow")) {     //if the object was the yellowKey
                GameManager.instance.yellowKey = true;         //set yellowKey to true
            }
        }
    }
}

