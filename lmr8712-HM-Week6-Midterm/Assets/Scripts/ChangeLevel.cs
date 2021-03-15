using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    // When the collider is triggered
    private void OnTriggerEnter2D(Collider2D other) {
        if (GameManager.instance.level > 8)
        {
            SceneManager.LoadScene(sceneBuildIndex: 1);
        }
        else
        {
            GameManager.instance.GetComponent<ASCIILevelLoader>().CurrentLevel++; //change the value of currentLevel
            GameManager.instance.level++;
        }

    }
}
