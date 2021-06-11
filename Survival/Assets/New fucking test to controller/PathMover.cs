using Assets.New_fucking_test_to_controller;
using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMover : MonoBehaviour
{

    public AIDestinationSetter aIDestination;
    public AIPath aiPath;
    public Animator anim;

    [Header("Player")]
    public int position;
    public MoveController moveController;
    public CrewController crewController;
    public SelectedChars selectedChars;
    public bool MainChar;
    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<CharInfo>().charClasse.Type == EntityTypes.Enemies) { SetupEnemy(); } else { SetupPlayer(); }
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

    void SetupEnemy()
    {
        MainChar = false;

        anim = GetComponent<Animator>();
        aIDestination = GetComponent<AIDestinationSetter>();
        aiPath = GetComponent<AIPath>();
    }
    void SetupPlayer()
    {
        MainChar = false;
        crewController = FindObjectOfType<CrewController>();
        moveController = FindObjectOfType<MoveController>();
        anim = GetComponent<Animator>();
        aIDestination = GetComponent<AIDestinationSetter>();
        aiPath = GetComponent<AIPath>();
        position = crewController.GetNextFreePosition(gameObject);
    }
}
