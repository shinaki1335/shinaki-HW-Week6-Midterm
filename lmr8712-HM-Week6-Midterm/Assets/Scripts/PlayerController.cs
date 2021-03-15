using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float forceAmount = 5;               //variable for the speed
    
    private Rigidbody2D rb2D;                   //variable for the Rigidbody2d
    
    public static PlayerController instance;    //static variable will hold the Singleton

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
        rb2D = GetComponent<Rigidbody2D>();             //get the Rigidbody2d component
    }

    // Update is called once per frame
    void Update() {
        // Player's movement
        if (Input.GetKey(KeyCode.W)) {                  //when pressing w
            rb2D.AddForce(Vector2.up * forceAmount);    //add force to rb to move up
        }

        if (Input.GetKey(KeyCode.A)) {                  //when pressing A
            rb2D.AddForce(Vector2.left * forceAmount);  //add force to rb to move left
        }
        
        if (Input.GetKey(KeyCode.S)) {                  //when pressing S
            rb2D.AddForce(Vector2.down * forceAmount);  //add force to rb to move down
        }
        
        if (Input.GetKey(KeyCode.D)) {                  //when pressing D
            rb2D.AddForce(Vector2.right * forceAmount);  //add force to rb to move right
        }

        if (Input.GetKey(KeyCode.R))
        {
            GameManager.instance.GetComponent<ASCIILevelLoader>().LoadLevel();
            GameManager.instance.GetComponent<ASCIILevelLoader>().ResetPlayer();
            rb2D.velocity = Vector2.zero;
            rb2D.angularVelocity = 0f;
        }
    }
}
