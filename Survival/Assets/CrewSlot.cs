using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewSlot : MonoBehaviour
{
    public GameObject member;
    public bool isFree;
    // Start is called before the first frame update
    void Start()
    {
        if (GetComponentInChildren<Member>() != null)
            member = GetComponentInChildren<Member>().gameObject;


    }

    // Update is called once per frame
    void Update()
    {
        isFree = member != null ? true : false; ;
    }
}
