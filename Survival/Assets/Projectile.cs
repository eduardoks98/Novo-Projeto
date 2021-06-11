using Assets.New_fucking_test_to_controller;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    public Vector3 target;
    public Rigidbody2D rb;
    public GameObject fromChar;
    public float damage;
    public GameObject damageInfo;
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
        if (collision.gameObject.layer == fromChar.layer) { return; }

        var damagee = fromChar.GetComponent<CharInfo>().cAttackPower + damage;
        collision.GetComponent<CharActions>().TakeDamage(damagee); 
        bool isCrit = Random.Range(0, 100) < 30;
        DamagePopup.Create(damageInfo, collision.transform.position, damagee, isCrit);
        Destroy(gameObject);

    }
}
