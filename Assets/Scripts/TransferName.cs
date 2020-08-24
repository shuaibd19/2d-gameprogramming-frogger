using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransferName : MonoBehaviour
{
    public string thePlayeName;
    public GameObject inputField;
    public GameObject textDisplay;
    public GameObject canvas;

    GameObject player;
    Player playa;
    private GameManager myGameManager; //A reference to the GameManager in the scene.
    public bool startTimer = false;
    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StoreName()
    {
        player = GameObject.Find("Player");
        playa = player.GetComponent<Player>();
        thePlayeName = inputField.GetComponent<Text>().text;

        playa.playerName = thePlayeName;
        textDisplay.GetComponent<Text>().text = "Hello There " + thePlayeName + "!";

        GameObject theManager = GameObject.Find("GameManager");
        myGameManager = theManager.GetComponent<GameManager>();

        myGameManager.isGameRunning = true;
        startTimer = true;
        canvas.SetActive(false);
    }
}
