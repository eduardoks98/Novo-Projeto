using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotManager : MonoBehaviour
{

    public int lenght;
    public LineRenderer lineRenderer;
    public Vector3[] segmentPoses;
    public Vector3[] segmentV;

    public Transform targetDir;
    public float targetDist;
    public float smoothSpeed;

    public GameObject[] bodyparts;

    public TeamManager teamManager;

    public GameObject[] Spots;
    private void Start()
    {

        lenght = bodyparts.Length + 1;
        lineRenderer.positionCount = lenght;
        segmentPoses = new Vector3[lenght];
        segmentV = new Vector3[lenght];
        teamManager = GameObject.FindGameObjectWithTag("Formation").GetComponent<TeamManager>();
        InitLineRenderer();
    }

    private void Update()
    {
        segmentPoses[0] = targetDir.position;

        for (int i = 1; i < segmentPoses.Length; i++)
        {
            Vector3 targetPos;
            if (i == 1)
            {
                targetPos = segmentPoses[i - 1] + (segmentPoses[i] - segmentPoses[i - 1]).normalized * 0;
            }
            else
            {
                targetPos = segmentPoses[i - 1] + (segmentPoses[i] - segmentPoses[i - 1]).normalized * targetDist;
            }


            segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i], targetPos, ref segmentV[i], smoothSpeed);

            int bodyPos = -1;
            if (bodyparts[i - 1].GetComponent<CharSlot>() != null)
            {
                bodyPos = bodyparts[i - 1].GetComponent<CharSlot>().position;
                if (bodyPos != -1)
                {
                    bodyparts[i - 1].transform.position = segmentPoses[teamManager.bodys[teamManager.getBodysIndex(bodyPos)].position];
                }
            }

            //bodyPositions[i - 1].position = i;
            // segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i], segmentPoses[i - 1] + targetDir.right * targetDist, ref segmentV[i], smoothSpeed);
        }

        lineRenderer.SetPositions(segmentPoses);
    }

    void InitLineRenderer()
    {
        lineRenderer.GetPositions(segmentPoses);
        segmentPoses[0] = targetDir.position;

        for (int i = 1; i < segmentPoses.Length; i++)
        {
            segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i], segmentPoses[i - 1] + targetDir.right * targetDist, ref segmentV[i], smoothSpeed);
        }
        
        lineRenderer.SetPositions(segmentPoses);
    }
}
