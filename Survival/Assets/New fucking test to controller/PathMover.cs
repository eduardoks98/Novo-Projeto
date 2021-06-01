using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMover : MonoBehaviour
{
    public int position;
    public MoveController moveController;
    public CrewController crewController;
    public SelectedChars selectedChars;
    public AIDestinationSetter aIDestination;
    public AIPath aiPath;
    public bool MainChar;
    public Animator anim;
    private void Awake()
    {
        MainChar = false;
        crewController = FindObjectOfType<CrewController>();
        moveController = FindObjectOfType<MoveController>();

    }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        aIDestination = GetComponent<AIDestinationSetter>();
        aiPath = GetComponent<AIPath>();
        position = crewController.GetNextFreePosition(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (position == -1)
        {
            aIDestination.target = null;
            return;
        }
        if (!MainChar)
        {
            if (position != 1)
                aIDestination.target = crewController.GetPositionTarget(position - 1);
            aiPath.enabled = true;
            aiPath.maxSpeed = moveController.runSpeed * 1.25f;
            anim.SetBool("isRunning", !aiPath.reachedEndOfPath);
            if (aiPath.desiredVelocity.x >= 0.2f)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
            else if (aiPath.desiredVelocity.x <= -0.2f)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }
        else
        {
            aiPath.enabled = false;
            if (GetComponent<Rigidbody2D>().velocity.x >= 0.01f)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
            else if (GetComponent<Rigidbody2D>().velocity.x <= -0.01f)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            anim.SetBool("isRunning", moveController.isRunning);
        }
        
    }
}
