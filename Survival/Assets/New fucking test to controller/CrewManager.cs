using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewManager : MonoBehaviour
{
    public List<GameObject> crewSlots = new List<GameObject>();
    public CrewController crewController;
    public Vector3[] segmentV;
    public Vector3[] segmentPoses;
    public Transform targetDir;
    public float targetDist;
    public float smoothSpeed;
    // Start is called before the first frame update
    void Start()
    {
        crewController = FindObjectOfType<CrewController>();
        crewSlots = GetSlots(crewController);
        segmentV = new Vector3[crewSlots.Count];
        segmentPoses = new Vector3[crewSlots.Count];
        segmentPoses[0] = crewSlots[0].transform.position;
        for (int i = 1; i < segmentPoses.Length; i++)
        {
            Vector3 targetPos = segmentPoses[i - 1] + (segmentPoses[i] - segmentPoses[i - 1]).normalized * targetDist;



            segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i], targetPos, ref segmentV[i], smoothSpeed);
            //segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i], segmentPoses[i-1] + (-targetDir.right) * targetDist, ref segmentV[i], smoothSpeed);
        }
        //UpdatePositions(segmentPoses);
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
        //UpdatePositions(segmentPoses);
    }

   

    public List<GameObject> GetSlots(CrewController controller)
    {
        List<GameObject> list = new List<GameObject>();
        foreach (var item in controller.characters)
        {
            list.Add(item.gameObject);
        }
        return list;
    }
   
}
