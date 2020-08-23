using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is to be attached to a GameObject called GameManager in the scene. It is to be used to manager the settings and overarching gameplay loop.
/// </summary>
public class GameManager : MonoBehaviour
{
    [Header("Scoring")]
    public static int currentScore = 0; //The current score in this round.
    public static int highScore = 0; //The highest score achieved either in this session or over the lifetime of the game.

    [Header("Playable Area")]
    public float levelConstraintTop; //The maximum positive Y value of the playable space.
    public float levelConstraintBottom; //The maximum negative Y value of the playable space.
    public float levelConstraintLeft; //The maximum negative X value of the playable space.
    public float levelConstraintRight; //The maximum positive X value of the playablle space.

    [Header("Gameplay Loop")]
    public bool isGameRunning = true; //Is the gameplay part of the game current active?
    //i made these static to avoid reseting to zero everytime the player reaches a house
    public static float totalGameTime = 0f; //The maximum amount of time or the total time avilable to the player.
    public static float gameTimeRemaining = 60f; //The current elapsed time

    GameObject player;
    string PlayaName = "";

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        Player playa = player.GetComponent<Player>();
        PlayaName = playa.playerName;
        highScore = PlayerPrefs.GetInt("HighScore");
        print("Hello!!!! " + PlayaName);
    }

    // Update is called once per frame
    void Update()
    {
        //logic for the game to only run for 60 seconds
        if (totalGameTime >= gameTimeRemaining && isGameRunning)
        {
            isGameRunning = false;
            print("You ran out of time!");
            //logic to check high score
            if (currentScore > highScore)
            {
                highScore = currentScore;
                PlayerPrefs.SetInt("HighScore", highScore);
            }
        }
        else
        {
            totalGameTime += Time.deltaTime;
            gameTimeRemaining -= Time.deltaTime; 
        }
    }

    //this is bad practice as someone could hack this but ....
    public void addPoints(int points)
    {
        currentScore += points;
        print("Your current score: " + currentScore);
    }

    public void deductPoints(int points)
    {
        if (currentScore > 0)
        {
            currentScore -= points;
            print("Your current score: " + currentScore);
        }
    }

    public int getCurrentPoints() { return currentScore; }
    public int getHighestScore() { return highScore; }
    public float getTimeRemaining() { return gameTimeRemaining; }
}
