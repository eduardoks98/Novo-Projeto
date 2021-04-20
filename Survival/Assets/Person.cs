using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : Util
{
    private Vector3 _savedPosition;
    [SerializeField]
    private List<SpriteRenderer> _sprites;

    private Util _util;


    [SerializeField]
    public List<Collider2D> colliders = new List<Collider2D>();

    public Vector3 SavedPosition { get => _savedPosition; set => _savedPosition = value; }
    public Util Util { get => _util; set => _util = value; }
    public List<SpriteRenderer> Sprites { get => _sprites; set => _sprites = value; }

    public List<Collider2D> GetColliders() { return colliders; }

    private void Start()
    {
        Util = new Util();
    }
    private void Update()
    {
        SavedPosition = Util.isBehind(colliders,this.transform, SavedPosition, Sprites);
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
