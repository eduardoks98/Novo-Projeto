using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Person : MonoBehaviour
{
    public IJobs Job;
    [SerializeField]
    private UIBars _healthBar;

    private MovementController moveController;

    [SerializeField]
    public List<Collider2D> colliders = new List<Collider2D>();


    public UIBars HealthBar { get => _healthBar; set => _healthBar = value; }

    public List<Collider2D> GetColliders() { return colliders; }

    private void Start()
    {
        moveController = gameObject.GetComponent<MovementController>();
        Job = new Survivalist();
        HealthBar.SetMaxValue(Job.MaxHealth);
    }
    private void Update()
    {
        moveController.Move(Job.CanMove);

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
