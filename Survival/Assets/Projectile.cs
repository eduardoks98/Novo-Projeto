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
    private float timer;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(transform.up * .2f, ForceMode2D.Impulse);
        timer += Time.deltaTime;
        if (timer > 10)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var layer = collision.gameObject.layer;
        if (layer == fromChar.layer) { return; }
        if (layer == 6)
        {
            Destroy(gameObject);
            return;
        }

        var damagee = fromChar.GetComponent<CharInfo>().cAttackPower + damage;
        if (collision.GetComponent<CharActions>() == null)
        {
            Debug.Log(collision.name);
        }
        collision.GetComponent<CharActions>().TakeDamage(damagee);
        bool isCrit = Random.Range(0, 100) < 30;
        DamagePopup.Create(damageInfo, collision.transform.position, damagee, isCrit);
        Destroy(gameObject);

    }
}
