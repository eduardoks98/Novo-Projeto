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

    public Char parentChar;
    public Enemy parentEnemy;
    public Vector3 pTransform;
    private void Awake()
    {
        objRenderer = gameObject.GetComponent<Renderer>();
        parentChar = GetComponentInParent<Char>();
        parentEnemy = GetComponentInParent<Enemy>();
    }

    private void Update()
    {
        if (parentChar != null) {

            pTransform = parentChar.parentTransform;
        }
        else if(parentEnemy!=null)
        {
            pTransform = parentEnemy.transform.position;
        }
        else
        {
            return;
        }
        if (sortGroup != null)
            sortGroup.sortingOrder = (int)(sortingBase - (pTransform.y * 100) - offset);
        objRenderer.sortingOrder = (int)(sortingBase - (pTransform.y * 100) - offset);

        if (runOnlyOnce)
        {
            Destroy(this);
        }
    }
}
