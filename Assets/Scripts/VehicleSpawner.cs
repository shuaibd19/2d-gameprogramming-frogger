﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour
{
    //reference to vehicle game object it will be spawning
    public GameObject vhcl;
    float countDown = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (countDown <= -0.04)
        {
            //create an instance of a vehicle
            SpawnVehicle();
            //reset the timer
            countDown = 0.5f;
        }
        else
        {
            //deduct in real time from countdown until it reaches the condition
            countDown -= Time.deltaTime;
        }
        
    }

    void SpawnVehicle()
    {
        Instantiate(vhcl);
    }
}
