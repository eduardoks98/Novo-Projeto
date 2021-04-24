using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Person : MonoBehaviour
{
    public ICharacterJob Job;
    [SerializeField]
    private UIBars _healthBar;

    [SerializeField]
    public List<Collider2D> colliders = new List<Collider2D>();

    public UIBars HealthBar { get => _healthBar; set => _healthBar = value; }

    public List<Collider2D> GetColliders() { return colliders; }

    private void Start()
    {
        Job = new Survivalist();
        HealthBar.SetMaxValue(Job.MaxHealth);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Job.TakeDamage(Job.Attack());
            HealthBar.SetValue(Job.CurrentHealth);
            Debug.Log("vida atual: " + Job.CurrentHealth);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Job.MaxHealth += 200;
            HealthBar.SetMaxValue(Job.MaxHealth);
            HealthBar.SetValue(Job.CurrentHealth + 200f);
            Job.CurrentHealth += 200f;
            Debug.Log("vida maxima: " + Job.MaxHealth);
            Debug.Log("vida atual: " + Job.CurrentHealth);
        }
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
