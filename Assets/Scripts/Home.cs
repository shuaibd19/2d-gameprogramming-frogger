﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
    //static bool isTrigger = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
    }

    public void destroyMePlease()
    {
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("home"))
        {
            Destroy(g);
        }
    }
}
