using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShortcutManagement;
using UnityEngine;

/// <summary>
/// This script must be used as the core Player script for managing the player character in the game.
/// </summary>
public class Player : MonoBehaviour
{
    public string playerName = ""; //The players name for the purpose of storing the high score
   
    int playerTotalLives; //Players total possible lives.
    int playerLivesRemaining; //PLayers actual lives remaining.
   
    bool playerIsAlive = true; //Is the player currently alive?
    bool playerCanMove = true; //Can the player currently move?

    Vector2 startPosition;

    Rigidbody2D rBody;

    private GameManager myGameManager; //A reference to the GameManager in the scene.

    // Start is called before the first frame update
    void Start()
    {
        startPosition.x = -2f;
        startPosition.y = -4f;
        transform.position = startPosition;
        playerTotalLives = 5;
        playerLivesRemaining = playerTotalLives;
        //get the rigidy body component attached to the object and assign to rbody
        rBody = GetComponent<Rigidbody2D>();
        myGameManager = GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //adding movement functionality to player using arrow keys
        //player's movement is not continous and only snaps into a single unit in the grid

        //------------------TODO------------------------
        //MAKE SURE THE PLAYER DOES NOT EXCEED BOUNDS OF WORLD SPACE
        //up

        if (playerLivesRemaining <= 0)
        {
            playerIsAlive = false;
            playerCanMove = false;
        }

        if (playerIsAlive && playerCanMove)
        {
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "vehicle")
        {
            playerLivesRemaining -= 1;
            print("Lives Remaining: " + playerLivesRemaining);
            transform.position = startPosition;
            myGameManager.deductPoints(myGameManager.getCurrentPoints() / 3);
        }
        else if (collision.tag == "home")
        {
            print("Yay!!");
            myGameManager.addPoints(50);
            transform.position = startPosition;
        }
    }

}
