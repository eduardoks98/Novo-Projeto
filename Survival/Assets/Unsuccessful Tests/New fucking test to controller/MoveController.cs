using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MoveController : MonoBehaviour
{

    public List<GameObject> crew;
    public LineRenderer line;
    private List<Vector3> points = new List<Vector3>();
    public Action<IEnumerable<Vector3>> newPath = delegate { };
    public Rigidbody2D body;
    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;
    public float runSpeed = 5.0f;

    public CrewController crewController;
    public bool isRunning;
    private void Awake()
    {
        line = GetComponent<LineRenderer>();
    }



    private float DistanceToLastPoint(Vector3 point)
    {
        if (!points.Any())
            return Mathf.Infinity;
        return Vector3.Distance(points.Last(), point);
    }



    // Start is called before the first frame update
    void Start()
    {
        crewController = FindObjectOfType<CrewController>();
        body = GetComponent<Rigidbody2D>();
        newPath(points);
    }

    // Update is called once per frame
    private void Update()
    {
        body = crewController.GetPositionGameobject(1).Char.GetComponent<Rigidbody2D>();
        var main = body.GetComponent<PathMover>();
        if (main)
        {
            main.MainChar = true;
        }


    }
    void FixedUpdate()
    {
        MoveInput();

        if (points.Count > 25)
        {
            List<Vector3> store = new List<Vector3>();
            var count = 0;
            for (int i = points.Count - 1; i >= points.Count - (crew.Count + 1); i--)
            {
                store.Add(points[(points.Count - (crew.Count + 1)) + count]);
                count++;
            }
            points.Clear();
            points = store;
            line.positionCount = points.Count;
            line.SetPositions(points.ToArray());
        }
        if (DistanceToLastPoint(body.transform.position) > .6f)
        {
            points.Add(body.transform.position);

            line.positionCount = points.Count;
            line.SetPositions(points.ToArray());
        }

        for (int i = 1; i < crew.Count + 1; i++)
        {
            if (line.positionCount -i> 0 )
            {

                crew[i - 1].transform.position =line.GetPosition(line.positionCount-i);
                CrewMember member = crew[i - 1].GetComponent<CrewMember>();
                if (member)
                {
                    member.target = crew[i - 1].transform;

                }
            }

        }
    }

    public void MoveInput()
    {
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down

        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        if (body.velocity.x!=0 || body.velocity.y!=0) {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
    }


}
