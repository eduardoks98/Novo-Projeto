using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    public Vector3 target;
    public Rigidbody2D rb;
    public LayerMask enemies;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(transform.up * .2f, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            Debug.Log(LayerMask.LayerToName(collision.gameObject.layer));


    }
}
