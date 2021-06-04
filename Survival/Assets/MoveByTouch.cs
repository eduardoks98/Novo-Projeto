using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByTouch : MonoBehaviour
{
    public Joystick joystick;
    Rigidbody2D body;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public float runSpeed = 5.0f;
    public bool isRunning = false;
    public bool needFlip;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    public void Move(bool canMove)
    {
        if (!canMove)
        {
            body.velocity = Vector2.zero;
            isRunning = false;
        }
        else
        {
            // Gives a value between -1 and 1
            horizontal = joystick.Horizontal; // -1 is left
            vertical = joystick.Vertical; // -1 is down
            if (horizontal >= .2f)
            {
                needFlip = true;
                horizontal = runSpeed;
            }
            else if (horizontal <= -.2f)
            {
                needFlip = false;
                horizontal = -runSpeed;
            }
            else
            {
                horizontal = 0f;
            }

            if (vertical >= .2f)
            {
                vertical = runSpeed;
            }
            else if (vertical <= -.2f)
            {
                vertical = -runSpeed;
            }
            else
            {
                vertical = 0f;
            }

            if (horizontal != 0 && vertical != 0) // Check for diagonal movement
            {
                // limit movement speed diagonally, so you move at 70% speed
                horizontal *= moveLimiter;
                vertical *= moveLimiter;
            }

            body.velocity = new Vector2(horizontal, vertical);
            if (body.velocity.x != 0 || body.velocity.y != 0)
                isRunning = true;
            else
                isRunning = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        Move(true);
    }
}
