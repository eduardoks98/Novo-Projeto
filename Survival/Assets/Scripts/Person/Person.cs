using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{



    [SerializeField]
    public List<Collider2D> colliders = new List<Collider2D>();

    public List<Collider2D> GetColliders() { return colliders; }

    private void Start()
    {
    }
    private void Update()
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
                this.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
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
                this.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                spriteRenderer.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            }
        }
    }



}
