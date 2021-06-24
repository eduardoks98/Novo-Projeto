﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Correct.Scripts.Invetory
{
    public class Character : MonoBehaviour
    {

        public CharacterStat Strength;
        public CharacterStat Vitality;
        public CharacterStat Intelligence;
        public CharacterStat Agility;


        [SerializeField] Inventory inventory;
        [SerializeField] EquipmentPanel equipmentPanel;
        [SerializeField] StatPanel statPanel;
        [SerializeField] ItemTooltip itemTooltip;
        [SerializeField] Image draggableItem;

        private ItemSlot dragItemSlot;

        private void OnValidate()
        {
            if (itemTooltip == null)
            {
                itemTooltip = FindObjectOfType<ItemTooltip>();
            }
        }
        private void Awake()
        {
            statPanel.SetStats(Strength, Vitality, Intelligence, Agility);
            statPanel.UpdateStatValues();

            //Setup Events;
            //Right Click
            inventory.OnRigtClickEvent += Equip;
            equipmentPanel.OnRigtClickEvent += Unequip;

            //Pointer Enter
            inventory.OnPointerEnterEvent += ShowTooltip;
            equipmentPanel.OnPointerEnterEvent += ShowTooltip;

            //Pointer Exit
            inventory.OnPointerExitEvent += HideTooltip;
            equipmentPanel.OnPointerExitEvent += HideTooltip;

            //Begin Drag
            inventory.OnBeginDragEvent += BeginDrag;
            equipmentPanel.OnBeginDragEvent += BeginDrag;

            //End Drag
            inventory.OnEndDragEvet += EndDrag;
            equipmentPanel.OnEndDragEvet += EndDrag;

            //Drag
            inventory.OnDragEvent += Drag;
            equipmentPanel.OnDragEvent += Drag;

            //Drop
            inventory.OnDropEvent += Drop;
            equipmentPanel.OnDropEvent += Drop;
        }

        private void Equip(ItemSlot itemSlot)
        {
            EquippableItem equippableItem = itemSlot.Item as EquippableItem;
            if (equippableItem != null)
            {
                Equip(equippableItem);
            }
        }

        private void Unequip(ItemSlot itemSlot)
        {
            EquippableItem equippableItem = itemSlot.Item as EquippableItem;
            if (equippableItem != null)
            {
                Unequip(equippableItem);
            }
        }

        private void ShowTooltip(ItemSlot itemSlot)
        {
            EquippableItem equippableItem = itemSlot.Item as EquippableItem;
            if (equippableItem != null)
            {
                itemTooltip.ShowTooltip(equippableItem);
            }
        }

        private void HideTooltip(ItemSlot itemSlot)
        {
            itemTooltip.HideTooltip();
        }

        private void BeginDrag(ItemSlot itemSlot)
        {
            if (itemSlot.Item != null)
            {
                dragItemSlot = itemSlot;
                draggableItem.sprite = itemSlot.Item.Icon;
                draggableItem.transform.position = Input.mousePosition;
                draggableItem.enabled = true;

            }
        }

        private void EndDrag(ItemSlot itemSlot)
        {
            dragItemSlot = null;
            draggableItem.enabled = false;
        }

        private void Drag(ItemSlot itemSlot)
        {
            if (draggableItem.enabled)
                draggableItem.transform.position = Input.mousePosition;

        }

        private void Drop(ItemSlot dropItemSlot)
        {
            //Se arrastar um item com os dois botoes o sistem entende que a funcao ja foi feita ao soltar um dos botoes e caso nao existir nenhum item send arrastado quando soltar algum botao do mouse simplesmente retorna pq nao tem nada pra trocar de slot
            if (dragItemSlot == null) { return; }

            if ()
            {

            }
            else
            if (dropItemSlot.CanReceiveItem(dragItemSlot.Item) && dragItemSlot.CanReceiveItem(dropItemSlot.Item))
            {
                EquippableItem dragItem = dragItemSlot.Item as EquippableItem;
                EquippableItem dropItem = dropItemSlot.Item as EquippableItem;

                if (dragItemSlot is EquipmentSlot)
                {
                    if (dragItem != null) dragItem.Unequip(this);
                    if (dropItem != null) dropItem.Equip(this);
                }
                if (dropItemSlot is EquipmentSlot)
                {

                    if (dragItem != null) dragItem.Equip(this);
                    if (dropItem != null) dropItem.Unequip(this);
                }
                statPanel.UpdateStatValues();
                Item draggedItem = dragItemSlot.Item;
                int draggedItemAmount = dragItemSlot.Amount;

                dragItemSlot.Item = dropItemSlot.Item;
                dragItemSlot.Amount = dropItemSlot.Amount;

                dropItemSlot.Item = draggedItem;
                dropItemSlot.Amount = draggedItemAmount;
            }
        }

        public void Equip(EquippableItem item)
        {
            if (inventory.RemoveItem(item))
            {
                EquippableItem previousItem;
                if (equipmentPanel.AddItem(item, out previousItem))
                {
                    if (previousItem != null)
                    {
                        inventory.AddItem(previousItem);
                        previousItem.Unequip(this);
                        statPanel.UpdateStatValues();
                    }
                    item.Equip(this);
                    statPanel.UpdateStatValues();
                }
                else
                {
                    inventory.AddItem(item);
                }
            }
        }

        public void Unequip(EquippableItem item)
        {
            if (!inventory.IsFull() && equipmentPanel.RemoveItem(item))
            {
                inventory.AddItem(item);
                item.Unequip(this);
                statPanel.UpdateStatValues();
            }
        }
    }
}