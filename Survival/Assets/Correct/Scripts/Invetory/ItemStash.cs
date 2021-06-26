﻿using EKS.Items;
using EKS.Panel;
using System.Collections;
using UnityEngine;

namespace Assets.Correct.Scripts.Invetory
{
    public class ItemStash : ItemContainer
    {
        [SerializeField] Transform itemsParent;
        [SerializeField] SpriteRenderer spriteRenderer;
        [SerializeField] KeyCode openKeyCode = KeyCode.E;


        private bool isInRange;
        private bool isOpen;

        protected override void OnValidate()
        {
            if (spriteRenderer == null)
                spriteRenderer = GetComponentInChildren<SpriteRenderer>();

            if (itemsParent != null)
                itemSlots = itemsParent.GetComponentsInChildren<ItemSlot>(includeInactive: true);

            spriteRenderer.enabled = false;
        }

        private void Update()
        {
            if (isInRange && Input.GetKeyDown(openKeyCode))
            {

                isOpen = !isOpen;
                itemsParent.gameObject.SetActive(isOpen);
            }
        }

        protected override void Start()
        {
            base.Start();
            itemsParent.gameObject.SetActive(false);
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
                if(!isInRange && isOpen)
                {
                    isOpen = false;
                    itemsParent.gameObject.SetActive(false);
                }
            }
        }
    }
}
