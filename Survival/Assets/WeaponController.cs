using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Person;
using UnityEngine;

public class WeaponController : MonoBehaviour
{

    public GameObject character;
    public List<Collider2D> colliders = new List<Collider2D>();
    public List<Collider2D> GetColliders() { return colliders; }

    public void Attack()
    {
        if (character.CompareTag("Player"))
        {
            foreach (Collider2D item in GetColliders)
            {
                item.gameObject.GetComponent<PlayerController>();
        }
        }
        else
        {
            foreach (Collider2D item in GetColliders)
            {
                item.gameObject.GetComponent<EnemyController>().TakeDamage();
        }
        }

    }
    void Start()
    {
        characer = GameObject.FindGameObjectWithTag("Player");
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
