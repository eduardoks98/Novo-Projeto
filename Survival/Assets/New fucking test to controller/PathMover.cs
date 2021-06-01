using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMover : MonoBehaviour
{
    public int position;
    private Queue<Vector3> pathPoints = new Queue<Vector3>();
    public MoveController moveController;
    public CrewController crewController;
    public AIDestinationSetter aIDestination;
    private void Awake()
    {
        
        crewController = FindObjectOfType<CrewController>();
        moveController = FindObjectOfType<MoveController>();
        moveController.newPath += SetPoints;
    }
    private void SetPoints(IEnumerable<Vector3> points)
    {
        pathPoints = new Queue<Vector3>(points);
    }
    // Start is called before the first frame update
    void Start()
    {
        aIDestination = GetComponent<AIDestinationSetter>();
        position = crewController.GetNextFreePosition();
    }

    // Update is called once per frame
    void Update()
    {
        aIDestination.target = crewController.GetPositionTarget(position);
    }
}
