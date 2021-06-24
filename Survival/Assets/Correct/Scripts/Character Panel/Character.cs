using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using EKS.Stat;
using EKS.Panel;
using EKS.Crafting;
using EKS.Items;

namespace EKS.Characters.Panel

{
    public class Character : MonoBehaviour
    {
        public int Health = 50;

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

        private void Start()
        {
            if (itemTooltip == null)
            {
                itemTooltip = FindObjectOfType<ItemTooltip>();
            }
            statPanel.SetStats(Strength, Agility, Intelligence, Vitality);
            statPanel.UpdateStatValues();

            //Setup Events;
            //Right Click
            inventory.OnRigtClickEvent += InventoryRightClick;
            equipmentPanel.OnRigtClickEvent += EquipmentPanelRightClick;

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

        private void InventoryRightClick(BaseItemSlot itemSlot)
        {
            if(itemSlot.Item is EquippableItem)
            {
                Equip((EquippableItem)itemSlot.Item);
            }else if(itemSlot.Item is UsableItem)
            {
                UsableItem usableItem = (UsableItem)itemSlot.Item;
                usableItem.Use(this);

                if (usableItem.IsConsumable)
                {
                    inventory.RemoveItem(usableItem);
                    usableItem.Destroy();
                }
            }
        }

        private void EquipmentPanelRightClick(BaseItemSlot itemSlot)
        {
            if (itemSlot.Item is EquippableItem)
            {
                Unequip((EquippableItem)itemSlot.Item);
            }
        }

        private void ShowTooltip(BaseItemSlot itemSlot)
        {
            if (itemSlot.Item != null)
            {
                itemTooltip.ShowTooltip(itemSlot.Item);
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
            draggableItem.enabled = false;
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
            if (!inventory.CanAddItem(item) && equipmentPanel.RemoveItem(item))
            {
                inventory.AddItem(item);
                item.Unequip(this);
                statPanel.UpdateStatValues();
            }
        }

        public void UpdateStatValues()
        {
            statPanel.UpdateStatValues();
        }
    }
}