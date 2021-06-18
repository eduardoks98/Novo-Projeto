using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public GameObject arrow;
    public Transform shotPoint;
    public float lauchForce;
    public Person player;
    private float attackTimer = 0f;
    private float moveTimer = 0f;
    public bool canAttack = true;
    public bool canMove = true;
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

        Shoot();
        PlayerMove();
    }

    void Shoot()
    {
        if (attackTimer <= 0)
        {
            canAttack = true;

        }
        else if (!canAttack)
        {
            attackTimer -= Time.deltaTime;
        }
        if (Input.GetMouseButtonDown(0) && canAttack)
        {
            GameObject newArrow = Instantiate(arrow, shotPoint.position, shotPoint.rotation);
            newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * lauchForce;
            canAttack = false;
            attackTimer = player.Job.AttackSpeed;
            canMove = false;
            moveTimer = player.Job.StopMoveWhenAttack;
        }

    }

    void PlayerMove()
    {
        if (moveTimer <= 0)
        {
            canMove = true;
        }
        else
        {
            moveTimer -= Time.deltaTime;
        }
        player.Job.CanMove = canMove;
    }
}
