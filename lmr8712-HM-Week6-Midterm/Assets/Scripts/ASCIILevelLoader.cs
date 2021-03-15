using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ASCIILevelLoader : MonoBehaviour
{
    // Store prefabs of the object that will be added to the scene
    public GameObject coin;
    public GameObject player;
    public GameObject wall;
    public GameObject portal;
    public GameObject level;
    public GameObject redDoor;
    public GameObject blueDoor;
    public GameObject greenDoor;
    public GameObject yellowDoor;
    public GameObject redKey;
    public GameObject blueKey;
    public GameObject greenKey;
    public GameObject yellowKey;
    public GameObject currentPlayer;
    
    // Create variable for the current position of the player
    private Vector2 startPosition;

    // Create variables to control the level's position
    public float offsetX;
    public float offsetY;

    // Name of the level file
    public string fileName;

    // Variable for the current level
    public int currentLevel;

    // Property for the currentLevel
    // Changes the level that is going to be load
    public int CurrentLevel {
        get { return currentLevel;}                                    //get the currentLevel variable
        set {
            currentLevel = value;                                      //set it to value
            LoadLevel();                                               //load the level
            startPosition = currentPlayer.transform.position;   // store the start the start position og the player
        }  
    }

    // Start is called before the first frame update
    void Start() {
        LoadLevel();                    //call the LoadLevel function
    }
    
    // Function that creates a level based on the ASCII Text File
    public void LoadLevel() {
        Destroy(level);                              //destroy the current level
        level = new GameObject("Level");        //create a new level object
        // Make all the keys false at the start of each level
        GameManager.instance.blueKey = false;
        GameManager.instance.greenKey = false;
        GameManager.instance.redKey = false;
        GameManager.instance.yellowKey = false;
        
        // Build a new level path based on the currentLevel
        string current_file_path =
            Application.dataPath + 
            "/Levels/" + 
            fileName.Replace("Num", currentLevel + "");   //replace the a string with another string

        // Pull the contents of the file into a string array, each line is an item of the array
        string[] fileLines = File.ReadAllLines(current_file_path);
        
        for(int y = 0; y < fileLines.Length; y++) {                     //loop through each line
            string lineText = fileLines[y];                             //get the current line
            
            char[] characters = lineText.ToCharArray();                 //split the line into a characters arrays

            for (int x = 0; x < characters.Length; x++) {               //loop through each character
                char c = characters[x];                                 //get current character

                GameObject newObject;                                   //create new object
                switch (c) {                                            //switch statement for the characters
                    case 'b':                                           //if the character is 'b'
                        newObject = Instantiate<GameObject>(blueDoor);  //make a blueDoor
                        break;
                    
                    case 'B':                                           //if the character is 'B'
                        newObject = Instantiate<GameObject>(blueKey);   //make a blueKey
                        break;
                    
                    case 'c':                                           //if the character is 'c'
                        newObject = Instantiate<GameObject>(coin);      //make a coin
                        break;
                    
                    case 'g':                                           //if the character is 'g'
                        newObject = Instantiate<GameObject>(greenDoor); //make a greenDoor
                        break;
                    
                    case 'G':                                           //if the character is 'G'
                        newObject = Instantiate<GameObject>(greenKey);  //make a greenKey
                        break;
                    
                    case 'p':                                           //if the character is 'p'
                        newObject = Instantiate<GameObject>(player);    //make the player
                        if (currentPlayer == null){                     //if not object on the currentPlayer
                            currentPlayer = newObject;                  //store this object
                            startPosition = new Vector2(                //create variable to store the start position
                                x + offsetX, -y + offsetY);
                        }
                        break;

                    case 'r':                                           //if the character is 'r'
                        newObject = Instantiate<GameObject>(redDoor);   //make a redDoor
                        break;
                    
                    case 'R':                                           //if the character is 'R'
                        newObject = Instantiate<GameObject>(redKey);    //make a redKey
                        break;
                        
                    case 'w':                                           //if the character is 'w'
                        newObject = Instantiate<GameObject>(wall);      //make a wall
                        break;

                    case 'y':                                             //if the character is 'y'
                        newObject = Instantiate<GameObject>(yellowDoor);  //make a yellowDoor
                        break;
                    
                    case 'Y':                                             //if the character is 'Y'
                        newObject = Instantiate<GameObject>(yellowKey);  //make a yellowKey
                        break;
                    
                    case '&':                                              //if the character is '&'
                        newObject = Instantiate<GameObject>(portal);       //create a portal
                        break;
                    
                    default:                                               //if any other character
                        newObject = null;                                  //make newObject null
                        break;
                }

                if (newObject != null) {                                    //if newObjects not null
                    if(!newObject.name.Contains("Player")) {                //and is not player

                        newObject.transform.parent = level.transform;       //make the level gameObject it's parent
                    }
                    newObject.transform.position =                          //create the newObjects position based
                        new Vector3(x + offsetX, -y + offsetY, 0);     //on offset and their position in the file
                }
            }
        }
    }

    // Function to reset the player
    public void ResetPlayer() {
        currentPlayer.transform.position = startPosition;               // move player to start position
    }
}
