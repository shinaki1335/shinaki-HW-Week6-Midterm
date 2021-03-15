using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    private int lastLevel = 8;
    
    // When the collider is triggered
    private void OnTriggerEnter2D(Collider2D other) {
        if (GameManager.instance.level > lastLevel) {                             //if last level completed
            SceneManager.LoadScene(sceneBuildIndex: 1);                           //load GameOver scene
            GameManager.instance.inGame = false;                                  //change inGame to false
        }
        else {
            GameManager.instance.GetComponent<ASCIILevelLoader>().CurrentLevel++; //change the value of currentLevel
            GameManager.instance.level++;                                         //add one to level variable
        }
    }
}
