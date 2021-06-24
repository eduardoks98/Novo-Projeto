using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using EKS.Stat;
using EKS.Panel;
using EKS.Crafting;

namespace EKS.Characters.Panel

{
    public class Character : MonoBehaviour
    {

        public CharacterStat Strength;
        public CharacterStat Vitality;
        public CharacterStat Intelligence;
        public CharacterStat Agility;


        [SerializeField] Inventory inventory;
        [SerializeField] EquipmentPanel equipmentPanel;
        [SerializeField] CraftingWindow craftingWindow;
        [SerializeField] StatPanel statPanel;
        [SerializeField] ItemTooltip itemTooltip;
        [SerializeField] Image draggableItem;

        private BaseItemSlot dragItemSlot;

        private void OnValidate()
        {
            if (itemTooltip == null)
            {
                itemTooltip = FindObjectOfType<ItemTooltip>();
            }
        }
        private void Start()
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
            //craftingWindow.OnPointerEnterEvent += ShowTooltip;

            //Pointer Exit
            inventory.OnPointerExitEvent += HideTooltip;
            equipmentPanel.OnPointerExitEvent += HideTooltip;
            // craftingWindow.OnPointerExitEvent += HideTooltip;

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

        private void Equip(BaseItemSlot itemSlot)
        {
            EquippableItem equippableItem = itemSlot.Item as EquippableItem;
            if (equippableItem != null)
            {
                Equip(equippableItem);
            }
        }

        private void Unequip(BaseItemSlot itemSlot)
        {
            EquippableItem equippableItem = itemSlot.Item as EquippableItem;
            if (equippableItem != null)
            {
                Unequip(equippableItem);
            }
        }

        private void ShowTooltip(BaseItemSlot itemSlot)
        {
            EquippableItem equippableItem = itemSlot.Item as EquippableItem;
            if (equippableItem != null)
            {
                itemTooltip.ShowTooltip(equippableItem);
            }
        }

        private void HideTooltip(BaseItemSlot itemSlot)
        {
            itemTooltip.HideTooltip();
        }

        private void BeginDrag(BaseItemSlot itemSlot)
        {
            if (itemSlot.Item != null)
            {
                dragItemSlot = itemSlot;
                draggableItem.sprite = itemSlot.Item.Icon;
                draggableItem.transform.position = Input.mousePosition;
                draggableItem.enabled = true;

            }
        }

        private void EndDrag(BaseItemSlot itemSlot)
        {
            dragItemSlot = null;
            draggableItem.gameObject.SetActive(false);
        }

        private void Drag(BaseItemSlot itemSlot)
        {
            if (draggableItem.enabled)
                draggableItem.transform.position = Input.mousePosition;

        }

        private void Drop(BaseItemSlot dropItemSlot)
        {
            //Se arrastar um item com os dois botoes o sistem entende que a funcao ja foi feita ao soltar um dos botoes e caso nao existir nenhum item send arrastado quando soltar algum botao do mouse simplesmente retorna pq nao tem nada pra trocar de slot
            if (dragItemSlot == null) { return; }
            if (dropItemSlot.CanAddStack(dragItemSlot.Item))
            {
                AddStacks(dropItemSlot);
            }
            else if (dropItemSlot.CanReceiveItem(dragItemSlot.Item) && dragItemSlot.CanReceiveItem(dropItemSlot.Item))
            {
                SwapItems(dropItemSlot);
            }
        }

        private void SwapItems(BaseItemSlot dropItemSlot)
        {
            EquippableItem dragEquipItem = dragItemSlot.Item as EquippableItem;
            EquippableItem dropEquipItem = dropItemSlot.Item as EquippableItem;

            if (dragItemSlot is EquipmentSlot)
            {
                if (dragEquipItem != null) dragEquipItem.Unequip(this);
                if (dropEquipItem != null) dropEquipItem.Equip(this);
            }
            if (dropItemSlot is EquipmentSlot)
            {
                if (dragEquipItem != null) dragEquipItem.Equip(this);
                if (dropEquipItem != null) dropEquipItem.Unequip(this);
            }
            statPanel.UpdateStatValues();
            Item draggedItem = dragItemSlot.Item;
            int draggedItemAmount = dragItemSlot.Amount;

            dragItemSlot.Item = dropItemSlot.Item;
            dragItemSlot.Amount = dropItemSlot.Amount;

            dropItemSlot.Item = draggedItem;
            dropItemSlot.Amount = draggedItemAmount;
        }

        private void AddStacks(BaseItemSlot dropItemSlot)
        {
            int numAddableStacks = dropItemSlot.Item.MaximumStacks - dropItemSlot.Amount;
            int stacksToAdd = Mathf.Min(numAddableStacks, dragItemSlot.Amount);

            dropItemSlot.Amount += stacksToAdd;
            dragItemSlot.Amount -= stacksToAdd;
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