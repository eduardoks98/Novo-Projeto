using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public GameObject target;
    public bool hasTarget = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasTarget==false)
        {
            hasTarget = true;
            target = other.gameObject;
            Debug.Log(target.name);
        }
    }


}
