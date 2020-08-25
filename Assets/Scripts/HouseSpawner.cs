using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseSpawner : MonoBehaviour
{
    public GameObject house;
    static Vector3 home1;
    static Vector3 home2;
    static Vector3 home3;
    static Vector3 home4;
    static Vector3 home5;

    // Start is called before the first frame update
    void Start()
    {
        home1.x = -20f;
        home2.x = -13f;
        home3.x = -4f;
        home4.x = 4f;
        home5.x = 12f;

        home1.y = 16f;
        home2.y = 16f;
        home3.y = 16f;
        home4.y = 16f;
        home5.y = 16f;

        home1.z = -25;
        home2.z = -25;
        home3.z = -25;
        home4.z = -25;
        home5.z = -25;

        Instantiate(house, home1, Quaternion.identity);
        Instantiate(house, home2, Quaternion.identity);
        Instantiate(house, home3, Quaternion.identity);
        Instantiate(house, home4, Quaternion.identity);
        Instantiate(house, home5, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void resetHouses()
    {
        if (!isThereObject(home1))
        {
            Instantiate(house, home1, Quaternion.identity);
        }

        if (!isThereObject(home2))
        {
            Instantiate(house, home2, Quaternion.identity);
        }

        if (!isThereObject(home3))
        {
            Instantiate(house, home3, Quaternion.identity);
        }

        if (!isThereObject(home4))
        {
            Instantiate(house, home4, Quaternion.identity);
        }
        
        if (!isThereObject(home5))
        {
            Instantiate(house, home5, Quaternion.identity);
        }
    }

    public bool isThereObject(Vector3 pos)
    {
        Collider[] intersecting = Physics.OverlapSphere(pos, 0.001f);
        if (intersecting.Length != 0)
        {
            //something is there
            return true;
        }
        else
        {
            //there is nothing there
            return false;
        }
    }
}
