using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public bool isGameRunning = false; //Is the gameplay part of the game current active?
    //i made these static to avoid reseting to zero everytime the player reaches a house
    public float totalGameTime = 0f; //The maximum amount of time or the total time avilable to the player.
    public float gameTimeRemaining = 60f; //The current elapsed time

    GameObject player;
    Player playa;
    TransferName trsnfrName;
    string playaName = "";
    string currentPlayer = "";
    public GameObject restartGUI;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playa = player.GetComponent<Player>();
        
        GameObject trnsfer = GameObject.Find("InputName");
        trsnfrName = trnsfer.GetComponent<TransferName>();

        currentPlayer = playa.playerName;
        restartGUI.SetActive(false);
        //PlayerPrefs.DeleteAll();

        highScore = PlayerPrefs.GetInt("HighScore");
        playaName = PlayerPrefs.GetString("PlayerName", "John");
    }

    // Update is called once per frame
    void Update()
    {
        //logic for the game to only run for 60 seconds
        if (totalGameTime >= gameTimeRemaining && isGameRunning)
        {
            restartGUI.SetActive(true);
            isGameRunning = false;
            print("You ran out of time!");
            //logic to check high score
            if (currentScore > highScore)
            {
                storeScore();
            }
        }
        else
        {
            if (trsnfrName.startTimer && isGameRunning)
            {
                totalGameTime += Time.deltaTime;
                gameTimeRemaining -= Time.deltaTime;
            }
        }
    }

    //this is bad practice as someone could hack this but ....
    public void addPoints(int points)
    {
        currentScore += points;
        //print("Your current score: " + currentScore);
    }

    public void deductPoints(int points)
    {
        if (currentScore > 0)
        {
            currentScore -= points;
            //print("Your current score: " + currentScore);
        }
    }

    public int getCurrentPoints() { return currentScore; }
    public int getHighestScore() { return highScore; }
    public float getTimeRemaining() { return gameTimeRemaining; }
    public string getName() { return playaName; }

    public void restartGame()
    {
        if (!isGameRunning)
        {
            restartGUI.SetActive(false);
            gameTimeRemaining = 60f;
            totalGameTime = 0f;
            playa.transform.position = playa.startPosition;
            playa.resetLives();
            isGameRunning = true;

            playa.playerIsAlive = true;
            playa.playerCanMove = true;
        }
    }

    public void storeScore()
    {
        highScore = currentScore;
        PlayerPrefs.SetInt("HighScore", highScore);

        playaName = currentPlayer;
        PlayerPrefs.SetString("PlayerName", playaName);
    }
}
