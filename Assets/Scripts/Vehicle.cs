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
    Vector2 startingPosition; //This variable is to be used to indicate where on the map the vehicle starts (or spawns)
    Vector2 endPosition; //This variablle is to be used to indicate the final destination of the vehicle.

    Rigidbody2D rBody;
    Vector2 fwd;
    float maxSpeed = 10f; //setting the upper limit of vehicle spawn speed when randomising
    float minSpeed = 5f; //setting the lower limit of vehicle spawn speed when randomising
    float speed; //This variable is to be used to control the speed of the vehicle.

    int moveDirection; //This variabe is to be used to indicate the direction the vehicle is moving in.
    float dirMax = 2f;
    float dirMin = -2f;

    int whichLane;

    public int getLane() { return whichLane; }

    // Start is called before the first frame update
    void Start()
    {
        whichLane = Random.Range(-3, 2);
        rBody = GetComponent<Rigidbody2D>();
        //randomising speed at spawn time
        speed = Random.Range(maxSpeed, minSpeed);
        //randomising movedirection of vehicle at spawn time
        if (Random.Range(dirMax, dirMin) > 0)
        {
            //go right
            moveDirection = 1;

            //makes some conditions for the y axis lane positions
            if (whichLane == -3)
            {
                startingPosition.y = -3f;
                endPosition.y = startingPosition.y;
            }
            else if (whichLane == -2)
            {
                startingPosition.y = -2f;
                endPosition.y = startingPosition.y;
            }
            else if (whichLane == -1)
            {
                startingPosition.y = -1f;
                endPosition.y = startingPosition.y;
            }
            else if (whichLane == 0)
            {
                startingPosition.y = 0f;
                endPosition.y = startingPosition.y;
            }

            else if (whichLane == 1)
            {
                startingPosition.y = 1f;
                endPosition.y = startingPosition.y;
            }

            else if (whichLane == 2)
            {
                startingPosition.y = 2f;
                endPosition.y = startingPosition.y;
            }

            startingPosition.x = -11f;
            endPosition.x = 8f;
        }
        else
        {
            //go left
            moveDirection = -1;

            //makes some conditions for the y axis lane positions
            if (whichLane == -3)
            {
                startingPosition.y = -3f;
                endPosition.y = startingPosition.y;
            }
            else if (whichLane == -2)
            {
                startingPosition.y = -2f;
                endPosition.y = startingPosition.y;
            }
            else if (whichLane == -1)
            {
                startingPosition.y = -1f;
                endPosition.y = startingPosition.y;
            }
            else if (whichLane == 0)
            {
                startingPosition.y = 0f;
                endPosition.y = startingPosition.y;
            }

            else if (whichLane == 1)
            {
                startingPosition.y = 1f;
                endPosition.y = startingPosition.y;
            }

            else if (whichLane == 2)
            {
                startingPosition.y = 2f;
                endPosition.y = startingPosition.y;
            }

            startingPosition.x = 6.5f;
            endPosition.x = -13f;
        }

        //set the vehicles starting position
        transform.position = startingPosition;
    }

    private void FixedUpdate()
    {
        //movement of vehicle along the x axis
        fwd = new Vector2(transform.right.x, transform.right.y);
        rBody.MovePosition(rBody.position + fwd * Time.fixedDeltaTime * speed * moveDirection);

        if (transform.position.x < -13f || transform.position.x > 8f)
        {
            Destroy(this.gameObject);
        }
    }

}
