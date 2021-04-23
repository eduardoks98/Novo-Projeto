using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityColor : MonoBehaviour
{

    private SpriteRenderer[] parts;

    public Color color;
    // Start is called before the first frame update
    void Start()
    {
        parts = gameObject.GetComponentsInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var item in parts)
        {
            item.color = color;
        }
    }
}
