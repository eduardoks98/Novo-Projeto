using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewController : MonoBehaviour
{
    public CrewManager crewManager;
    public GameObject target;

    Rigidbody2D body;
    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;
    public float runSpeed = 5.0f;
    public bool isRunning = false;
    // Start is called before the first frame update
    void Start()
    {
        target = crewManager.crewSlots[0];
        body = target.GetComponent<Rigidbody2D>();
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
            horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
            vertical = Input.GetAxisRaw("Vertical"); // -1 is down

            if (horizontal != 0 && vertical != 0) // Check for diagonal movement
            {
                // limit movement speed diagonally, so you move at 70% speed
                horizontal *= moveLimiter;
                vertical *= moveLimiter;
            }

            body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
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
