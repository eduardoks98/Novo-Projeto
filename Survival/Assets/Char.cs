using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char : MonoBehaviour
{

    public Vector3 parentTransform;
    public CharSlot bodyRotation;
    private EntityColor entityColor;
    public Color color;
    void Start()
    {
        bodyRotation = GetComponentInParent<CharSlot>();
        entityColor = GetComponentInChildren<EntityColor>();
    }

    private void Update()
    {
        if (bodyRotation != null)
        {
            parentTransform = bodyRotation.currentTransform;
            this.transform.SetParent(bodyRotation.transform);
        }
        entityColor.color = color;
    }
}
