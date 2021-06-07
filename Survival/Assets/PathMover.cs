using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMover : MonoBehaviour
{
    private Queue<Vector3> pathPoints = new Queue<Vector3>();
    public Rigidbody2D rb;

    private void Awake()
    {
        FindObjectOfType<MoveController>().newPath += SetPoints;
    }

    private void SetPoints(IEnumerable<Vector3> points)
    {
        pathPoints = new Queue<Vector3>(points);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
}
