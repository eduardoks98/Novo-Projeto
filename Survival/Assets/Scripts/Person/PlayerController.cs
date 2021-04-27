using Assets.Scripts.Interfaces.Entity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Person
{
    [ExecuteInEditMode]
    [RequireComponent(typeof(Animator))]
    public class PlayerController : MonoBehaviour
    {
        public IEntity entity;
        [SerializeField]
        public IEntity stats;
        public Animator anim;
        public bool runOnce;
        public bool faster;
        public MovementController moveController;
        private UIBars _healthBar;
        public List<Collider2D> colliders = new List<Collider2D>();
        public UIBars HealthBar { get => _healthBar; set => _healthBar = value; }
        public List<Collider2D> GetColliders() { return colliders; }

        private void Start()
        {
            moveController = GetComponent<MovementController>();
            anim = GetComponent<Animator>();
            entity = new Warrior();
            stats = new StatsController(entity);
            runOnce = false;
            faster = false;
            HealthBar.SetMaxValue(stats.Health);
        }

        private void FixedUpdate()
        {
            if (faster && !runOnce)
            {
                stats.AddDexterity(100);
                runOnce = true;
            }

            if (stats == null) { return; }
            moveController.runSpeed = stats.Speed;
            float animSpeed = 1 + (stats.Dexterity / 100);
            anim.SetFloat("Speed", animSpeed);
            moveController.Move(true);

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
}