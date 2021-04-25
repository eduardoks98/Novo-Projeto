using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody2D rb;
    float _expireTime = 10f;
    [SerializeField]
    float _timer = 0f;

    public Person player;

    public float arrowRangeToFollow;
    public CircleCollider2D circle;
    public FollowTarget target;
    public BoxCollider2D boxCollider;
    public Bow bow;
    bool hasHit;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Person>();
        bow = GameObject.FindObjectsOfType<Bow>()[0];
        circle = gameObject.GetComponentInChildren<CircleCollider2D>();
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        target = gameObject.GetComponentInChildren<FollowTarget>();
       
        rb = GetComponent<Rigidbody2D>();
        hasHit = false;
    }
    private void FixedUpdate()
    {
        circle.radius = arrowRangeToFollow;
        if (_timer >= _expireTime)
        {
            _timer = 0f;
            Destroy(this.gameObject);
        }
        _timer += Time.deltaTime;
        
        if (target.target != null && rb!=null)
        {
            Debug.Log("TARGADO");
            Vector2 direction = target.target.transform.position - this.transform.position;
            transform.right = direction;
            rb.velocity = transform.right * bow.lauchForce;

            float angle = Mathf.Atan2(rb.velocity.x, rb.velocity.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, -Vector3.forward);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasHit) { return; }
        if (other.gameObject.layer == 8)
        {
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;
            hasHit = true;
        }
        if (other.gameObject.layer == 9 && boxCollider.IsTouching(other))
        {
            rb.velocity = Vector2.zero;
            if (other.gameObject.GetComponent<Rigidbody2D>() != null)
            {
                Debug.Log("Entrando");
                var t = other.gameObject.GetComponentInChildren<Attach>();
                gameObject.transform.parent = t.transform;
                hasHit = true;
                var enemy = other.gameObject.GetComponent<EnemyController>();
                enemy.TakeDamage(player.Job.Attack());
                Destroy(gameObject.GetComponent<Rigidbody2D>());
               
            }
        }

        if (other.gameObject.CompareTag("Occludable"))
        {
            this.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Occludable"))
        {
            this.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
    }



    

}
