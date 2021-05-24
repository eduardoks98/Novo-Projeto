using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentacle : MonoBehaviour
{

    public int lenght;
    public LineRenderer lineRenderer;
    public Vector3[] segmentPoses;
    public Vector3[] segmentV;

    public Transform targetDir;
    public float targetDist;
    public float smoothSpeed;

    public Transform[] bodyparts;
    private void Start()
    {
        lenght = bodyparts.Length;
        lineRenderer.positionCount = lenght;
        segmentPoses = new Vector3[lenght];
        segmentV = new Vector3[lenght];
    }

    private void Update()
    {
        segmentPoses[0] = targetDir.position;

        for (int i = 1; i < segmentPoses.Length; i++)
        {
            Vector3 targetPos = segmentPoses[i - 1] + (segmentPoses[i] - segmentPoses[i - 1]).normalized * targetDist;
            segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i], targetPos, ref segmentV[i], smoothSpeed);
            bodyparts[i -1].transform.position = segmentPoses[i];
            // segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i], segmentPoses[i - 1] + targetDir.right * targetDist, ref segmentV[i], smoothSpeed);
        }
        lineRenderer.SetPositions(segmentPoses);
    }
}
