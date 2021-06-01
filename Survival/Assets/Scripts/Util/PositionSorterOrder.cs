using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PositionSorterOrder : MonoBehaviour
{
    [SerializeField]
    private int sortingBase = 1000;
    [SerializeField]
    private int offset = 0;
    [SerializeField]
    private bool runOnlyOnce = false;
    [SerializeField]
    private Renderer objRenderer;
    [SerializeField]
    private SortingGroup sortGroup;

    public Char parentScript;
    public Vector3 parentPosition;
    private void Awake()
    {
        objRenderer = gameObject.GetComponent<Renderer>();
        parentScript = GetComponentInParent<Char>();
    }

    private void Update()
    {
        parentPosition = parentScript.parentTransform;
        if (sortGroup != null)
            sortGroup.sortingOrder = (int)(sortingBase - (parentPosition.y * 100) - offset);
        objRenderer.sortingOrder = (int)(sortingBase - (parentPosition.y * 100) - offset);

        if (runOnlyOnce)
        {
            Destroy(this);
        }
    }
}
