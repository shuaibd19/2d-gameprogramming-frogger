using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private GameManager myGameManager; //A reference to the GameManager in the scene.
    public Text scoreTxt;
    // Start is called before the first frame update
    void Start()
    {
        GameObject theManager = GameObject.Find("GameManager");
        myGameManager = theManager.GetComponent<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreTxt.text = "Score: " + myGameManager.getCurrentPoints().ToString();
    }
}
