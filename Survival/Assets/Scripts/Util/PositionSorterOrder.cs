using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PositionSorterOrder : MonoBehaviour
{
    [SerializeField]
    private int sortingBase = 500;
    [SerializeField]
    private int offset = 0;
    [SerializeField]
    private bool runOnlyOnce = false;
    [SerializeField]
    private Renderer objRenderer;
    [SerializeField]
    private SortingGroup sortGroup;
    private void Awake()
    {
        objRenderer = gameObject.GetComponent<Renderer>();
    }

    private void LateUpdate()
    {
        if (sortGroup != null)
            sortGroup.sortingOrder = (int)(sortingBase - transform.position.y - offset);
        objRenderer.sortingOrder = (int)(sortingBase - transform.position.y - offset);

        if (runOnlyOnce)
        {
            Destroy(this);
        }
    }
}
