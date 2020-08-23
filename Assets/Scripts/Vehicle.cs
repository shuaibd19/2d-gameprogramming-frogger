using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script must be utlised as the core component on the 'vehicle' obstacle in the frogger game.
/// </summary>
public class Vehicle : MonoBehaviour
{
    /// <summary>
    /// -1 = left, 1 = right
    /// </summary>
    public Vector2 startingPosition; //This variable is to be used to indicate where on the map the vehicle starts (or spawns)
    public Vector2 endPosition; //This variablle is to be used to indicate the final destination of the vehicle.

    Rigidbody2D rBody;
    Vector2 fwd;
    float maxSpeed = 10f; //setting the upper limit of vehicle spawn speed when randomising
    float minSpeed = 2.5f; //setting the lower limit of vehicle spawn speed when randomising
    float speed; //This variable is to be used to control the speed of the vehicle.

    int moveDirection; //This variabe is to be used to indicate the direction the vehicle is moving in.
    float dirMax = 2f;
    float dirMin = -2f;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        //randomising speed at spawn time
        speed = Random.Range(maxSpeed, minSpeed);
        //randomising movedirection of vehicle at spawn time
        if (Random.Range(dirMax, dirMin) > 0)
        {
            moveDirection = 1;
        }
        else
        {
            moveDirection = -1;
        }
    }

    private void FixedUpdate()
    {
        fwd = new Vector2(transform.right.x, transform.right.y);
        rBody.MovePosition(rBody.position + fwd * Time.fixedDeltaTime * speed * moveDirection);
    }

}
