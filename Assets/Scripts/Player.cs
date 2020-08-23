using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShortcutManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This script must be used as the core Player script for managing the player character in the game.
/// </summary>
public class Player : MonoBehaviour
{
    public string playerName = "Shuaib"; //The players name for the purpose of storing the high score
   
    static int playerTotalLives = 5; //Players total possible lives.
    static int playerLivesRemaining = playerTotalLives; //PLayers actual lives remaining.
   
    bool playerIsAlive = true; //Is the player currently alive?
    bool playerCanMove = true; //Can the player currently move?

    Vector2 startPosition;

    Rigidbody2D rBody;

    private GameManager myGameManager; //A reference to the GameManager in the scene.
    int houses = 5;

    // Start is called before the first frame update
    void Start()
    {
        //setting my reference to the game manager 
        GameObject theManager = GameObject.Find("GameManager");
        myGameManager = theManager.GetComponent<GameManager>();
        myGameManager.isGameRunning = true;

        startPosition.x = -2f;
        startPosition.y = -4f;
        transform.position = startPosition;
        //get the rigidy body component attached to the object and assign to rbody
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //------------------TODO------------------------
        //MAKE SURE THE PLAYER DOES NOT EXCEED BOUNDS OF WORLD SPACE

        //failure 
        if (playerLivesRemaining <= 0)
        {
            playerIsAlive = false;
            playerCanMove = false;
            myGameManager.isGameRunning = false;
            //add code here to capture the players points and time
        }

        //success
        if (houses == 0)
        {
            //add code here to capture the players points and time
            //reset the game and add other code
            playerLivesRemaining = playerTotalLives;
        }

        if (myGameManager.isGameRunning)
        {
            if (playerIsAlive && playerCanMove)
            {
                //up
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    rBody.MovePosition(rBody.position + Vector2.up);
                    myGameManager.addPoints(10);
                }
                //down
                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    rBody.MovePosition(rBody.position + Vector2.down);
                }
                //left
                else if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    rBody.MovePosition(rBody.position + Vector2.left);
                }
                //right
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    rBody.MovePosition(rBody.position + Vector2.right);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if the player hits an oncoming vehicle
        if (collision.tag == "vehicle")
        {
            //reduce the players life by one
            playerLivesRemaining -= 1;
            print("Lives Remaining: " + playerLivesRemaining);
            //deduct a third of the current players points
            myGameManager.deductPoints(myGameManager.getCurrentPoints() / 3);
            //reset the player at the base
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        //if the player hits one of the five houses
        if (collision.tag == "home")
        {
            print("Yay!!");
            //add points to the player
            myGameManager.addPoints(50);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //tally one off the houses
            houses -= 1;
        }
    }

}
