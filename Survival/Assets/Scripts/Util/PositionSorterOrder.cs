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

    public Vector3 pTransform;
    private void Awake()
    {
        objRenderer = gameObject.GetComponent<Renderer>();
    }

    private void Update()
    {
        pTransform = GetComponentInParent<Transform>().position;
        if (sortGroup != null)
            sortGroup.sortingOrder = (int)(sortingBase - (pTransform.y * 100) - offset);
        objRenderer.sortingOrder = (int)(sortingBase - (pTransform.y * 100) - offset);

        if (runOnlyOnce)
        {
            Destroy(this);
        }
    }
}
