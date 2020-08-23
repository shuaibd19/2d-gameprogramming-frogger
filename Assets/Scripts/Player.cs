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
   
    public int playerTotalLives; //Players total possible lives.
    public int playerLivesRemaining; //PLayers actual lives remaining.
   
    public bool playerIsAlive = true; //Is the player currently alive?
    public bool playerCanMove = true; //Can the player currently move?

    public float playerSpeed = 5f;

    Rigidbody2D rBody;

    private GameManager myGameManager; //A reference to the GameManager in the scene.

    // Start is called before the first frame update
    void Start()
    {
        //get the rigidy body component attached to the object and assign to rbody
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //adding movement functionality to player using arrow keys
        //player's movement is not continous and only snaps into a single unit in the grid

        //------------------TODO------------------------
        //MAKE SURE THE PLAYER DOES NOT EXCEED BOUNDS OF WORLD SPACE
        //up
        if (playerIsAlive)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                rBody.MovePosition(rBody.position + Vector2.up);
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
        else
        {
            playerCanMove = false;
        }

    }

}
