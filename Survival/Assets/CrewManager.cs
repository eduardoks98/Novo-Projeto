using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewManager : MonoBehaviour
{
    public List<GameObject> crewSlots = new List<GameObject>();
    public Vector3[] segmentV;
    public Vector3[] segmentPoses;
    public Transform targetDir;
    public float targetDist;
    public float smoothSpeed;
    public List<CrewSlot> crewSlotList { get => CrewSlotList(); }
    // Start is called before the first frame update
    void Start()
    {
        segmentV = new Vector3[crewSlots.Count];
        segmentPoses = new Vector3[crewSlots.Count];
        segmentPoses[0] = crewSlots[0].transform.position;
        for (int i = 1; i < segmentPoses.Length; i++)
        {
            Vector3 targetPos = segmentPoses[i - 1] + (segmentPoses[i] - segmentPoses[i - 1]).normalized * targetDist;



            segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i], targetPos, ref segmentV[i], smoothSpeed);
            //segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i], segmentPoses[i-1] + (-targetDir.right) * targetDist, ref segmentV[i], smoothSpeed);
        }
        UpdatePositions(segmentPoses);
    }


    // Update is called once per frame
    void Update()
    {

        segmentPoses[0] = crewSlots[0].transform.position;
        for (int i = 1; i < segmentPoses.Length; i++)
        {
            Vector3 targetPos = segmentPoses[i - 1] + (segmentPoses[i] - segmentPoses[i - 1]).normalized * targetDist;



            segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i], targetPos, ref segmentV[i], smoothSpeed);
            //segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i], segmentPoses[i-1] + (-targetDir.right) * targetDist, ref segmentV[i], smoothSpeed);
        }
        UpdatePositions(segmentPoses);
    }

    void UpdatePositions(Vector3[] newPositions)
    {
        for (int i = 1; i < crewSlots.Count; i++)
        {
            CrewRB()[i].MovePosition(newPositions[i]);
        }
    }

    public List<Rigidbody2D> CrewRB()
    {
        List<Rigidbody2D> list = new List<Rigidbody2D>();
        foreach (GameObject slot in crewSlots)
        {
            list.Add(slot.GetComponent<Rigidbody2D>());
        }
        return list;
    }
    public List<CrewSlot> CrewSlotList()
    {
        List<CrewSlot> list = new List<CrewSlot>();
        foreach (GameObject slot in crewSlots)
        {
            list.Add(slot.GetComponent<CrewSlot>());
        }
        return list;
    }
}
