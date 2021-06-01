using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewMember : MonoBehaviour
{
    public GameObject Char;
    public Transform target;
    public int position;
    public bool isFree;
    // Start is called before the first frame update
    private void Awake()
    {
       isFree = true;
    }
    void Start()
    {

    }

    // Update is called once per frame


}
