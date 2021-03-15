using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    // When a collision is detected
    private void OnCollisionEnter2D(Collision2D other) {
        // Destroy the door if the players has the right color key and tries to open
        if (other.gameObject.name.Contains("Player"))       //check if the other object is the player
        {
            // If object is blueDoor and blueKey is true, destroy the door
            if (gameObject.name.Contains("Blue") && GameManager.instance.blueKey)
            {
                GameManager.instance.blueKey = false;
                Destroy(gameObject);
            }
            
            // If object is greenDoor and greenKey is true, destroy the door
            if (gameObject.name.Contains("Green") && GameManager.instance.greenKey)
            {
                GameManager.instance.greenKey = false;
                Destroy(gameObject);
            }
            
            // If object is redDoor and redKey is true, destroy the door           
            if (gameObject.name.Contains("Red") && GameManager.instance.redKey)
            {
                GameManager.instance.redKey = false;
                Destroy(gameObject);
            }
            
            // If object is yellowDoor and yellowKey is true, destroy the door
            if (gameObject.name.Contains("Yellow") && GameManager.instance.yellowKey)
            {
                GameManager.instance.yellowKey = false;
                Destroy(gameObject);
            }
        }
    }
}
