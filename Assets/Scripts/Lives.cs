using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    private Player myPlayer; //A reference to the GameManager in the scene.
    public Text livesTxt;
    // Start is called before the first frame update
    void Start()
    {
        GameObject thePlayer = GameObject.Find("Player");
        myPlayer = thePlayer.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        livesTxt.text = "Lives: " + myPlayer.getCurrentLives().ToString();
    }
}
