using System;
using UnityEngine;

namespace Assets.Correct.Scripts.Invetory
{
    public class ItemChest : MonoBehaviour
    {

        [SerializeField] Item item;
        [SerializeField] int amount = 1;
        [SerializeField] Inventory inventory;
        [SerializeField] SpriteRenderer spriteRenderer;
        [SerializeField] Color emptyColor;
        [SerializeField] KeyCode itemPickUpKeyCode = KeyCode.E;

        private bool isInRange;
        private bool isEmpty;

        private void OnValidate()
        {
            if (inventory == null)
                inventory = FindObjectOfType<Inventory>();

            if (spriteRenderer == null)
                spriteRenderer = GetComponentInChildren<SpriteRenderer>();

            spriteRenderer.sprite = item.Icon;
            spriteRenderer.enabled = false;
        }

        private void Update()
        {
            if (isInRange && Input.GetKeyDown(itemPickUpKeyCode))
            {
                if (!isEmpty)
                {
                    Item itemCopy = item.GetCopy();
                    if (inventory.AddItem(itemCopy))
                    {

                        amount--;
                        if (amount == 0)
                        {

                            isEmpty = true;
                            spriteRenderer.color = emptyColor;
                        }
                    }
                    else
                    {
                        itemCopy.Destroy();
                    }

                }
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            CheckCollision(collision.gameObject, true);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            CheckCollision(collision.gameObject, false);

        }

        void CheckCollision(GameObject gameObject, bool state)
        {
            if (gameObject.CompareTag("Player"))
            {
                isInRange = state;
                spriteRenderer.enabled = state;
            }
        }
    }
}
