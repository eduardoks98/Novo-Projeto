using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingPath : MonoBehaviour
{
    public float radius = 20;
    public IAstarAI ai;
    Vector3 position;
    void Start()
    {
        ai = GetComponent<IAstarAI>();
    }
    Vector3 PickRandomPoint()
    {
        var point = Random.insideUnitSphere * radius;
        point.z = 0;
        point += ai.position;
        position = point;
        return point;
    }
    void Update()
    {
        // Update the destination of the AI if
        // the AI is not already calculating a path and
        // the ai has reached the end of the path or it has no path at all
        if (!ai.pathPending && (ai.reachedDestination || !ai.hasPath))
        {
            ai.destination = PickRandomPoint();
            ai.SearchPath();
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(position, new Vector3(1,1,1));
    }
}

