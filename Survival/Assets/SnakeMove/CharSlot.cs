using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharSlot : MonoBehaviour
{

    public int position;
    public TextMeshProUGUI TextMesh;
    public Vector3 currentTransform;
    public bool isFree;
    public bool cannotRelease;

    private void Update()
    {
        currentTransform = gameObject.transform.position;
        TextMesh.text = position.ToString();
        isFree = GetComponentInChildren<Char>() == null ? true:false;
    }
}
