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

    // Variable to control state of the game
    public int level;
    public bool inGame = true;

    // Variables to control state of the keys 
    public bool blueKey;
    public bool greenKey;
    public bool redKey;
    public bool yellowKey;

    // Variable to store text
    public Text levelText;
    public Text timeText;
    public Text scoreText;

    // Variable to control the timer and score of the game
    private float runTime;
    private float timer;
    private int score;

    // Allows other places to access and modify the score variable
    public int Score {
        get { return score; }
        set { score = value; }
    }

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
    void Start() {
        timer = Time.time;          //make the timer start a Time.time
        level = 1;                  //start level at 1
    }
    // Update is called once per frame
    void Update() {
        string minutes = ((int) runTime / 60).ToString();           //string to keep track of the minutes in game
        string seconds = (runTime % 60).ToString("f2");       //string to kee track of the seconds in game
        if (inGame) {
            runTime = Time.time - timer;                            //make the time run
            timeText.text = "Time: " + minutes + ":" + seconds;     //display the time
            levelText.text = "Level: " + level;                     //display the level
        }

        else
        {
            timeText.text = "Time: " + minutes + ":" + seconds;     //display amount of time it took to complete
            levelText.text = "Game Completed";                      //display that the game is over
            scoreText.text = "Coins collected: " + "\n" + score;           //display amount of coin collected
        }
        
        
    }

}