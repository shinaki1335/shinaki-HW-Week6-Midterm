using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Static variable to make object a singleton
    public static GameManager instance;

    public int level;
    public bool blueKey;
    public bool greenKey;
    public bool redKey;
    public bool yellowKey;

    private float runTime;

    public Text levelText;
    public Text timeText;
    private float timer;

   
    // Called when the script instance is being loaded
    private void Awake() {                      
        // Make a Singleton to prevent more than one instance of an object
        if (instance == null) {                 //if instance hasn't been set
            DontDestroyOnLoad(gameObject);      //don't destroy object when loading a new scene
            instance = this;                    //set instance to this object
        }
        else {                                  //if instance is set to an object
            Destroy(gameObject);                //destroy this object
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        timer = Time.time;
        level = 1;
    }

    void Update()
    {
        if (level < 9)
        {
            runTime = Time.time - timer;
            string minutes = ((int) runTime / 60).ToString();
            string seconds = (runTime % 60).ToString("f2");
            timeText.text = "Time: " + minutes + ":" + seconds;
            levelText.text = "Level: " + level;
        }
    }

}