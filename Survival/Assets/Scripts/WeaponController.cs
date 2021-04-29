using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Person;
using UnityEngine;

public class WeaponController : MonoBehaviour
{

    public GameObject character;
    public List<Collider2D> colliders = new List<Collider2D>();
    public List<Collider2D> GetColliders() { return colliders; }
    public Animator animator;

    public void Attack()
    {
        if (character.CompareTag("Player"))
        {
            foreach (Collider2D item in GetColliders())
            {
                Debug.Log(item.name);
                item.gameObject.GetComponentInParent<EnemyController>().TakeDamage(character.GetComponent<PlayerController>().stats.PhysicPower);
            }
        }
        else
        {
            foreach (Collider2D item in GetColliders())
            {
                item.gameObject.GetComponent<PlayerController>().TakeDamage(character.GetComponent<EnemyController>().stats.PhysicPower);
            }
        }

    }
    void Start()
    {
        if (GetComponentInParent<EnemyController>() == null)
        {
            character = GetComponentInParent<PlayerController>().gameObject;
        }
        else
        {
            character = GetComponentInParent<EnemyController>().gameObject;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        colliders.Add(other);
        if (other.gameObject.CompareTag("Occludable"))
        {
            SpriteRenderer spriteRenderer = other.GetComponent<SpriteRenderer>();

            if (spriteRenderer != null)
            {
                this.GetComponentInChildren<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
                spriteRenderer.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        colliders.Remove(other);
        if (other.gameObject.CompareTag("Occludable"))
        {
            SpriteRenderer spriteRenderer = other.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                this.GetComponentInChildren<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                spriteRenderer.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            }
        }
    }
}
