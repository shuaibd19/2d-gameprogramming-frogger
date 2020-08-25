using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : MonoBehaviour
{
    public bool logContact;
    // Start is called before the first frame update
    void Start()
    {
        logContact = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.tag == "player")
        //{
        //    logContact = true;
        //}
    }
}
