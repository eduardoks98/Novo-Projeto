using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public GameObject arrow;
    public Transform shotPoint;
    public float lauchForce;
    public Person player;
    private float timer = 0f;
    public bool canAttack = true;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Person>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 bowPosition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - bowPosition;
        transform.right = direction;

        if (timer <= 0)
        {
            canAttack = true;
        }
        else if (!canAttack)
        {
            timer -= Time.deltaTime;
        }
        if (Input.GetMouseButtonDown(0)  && canAttack)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject newArrow = Instantiate(arrow, shotPoint.position, shotPoint.rotation);
        newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * lauchForce;
        canAttack = false;
        timer = player.Job.AttackSpeed;
    }
}
