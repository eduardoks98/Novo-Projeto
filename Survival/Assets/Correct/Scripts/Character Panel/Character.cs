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


        public InfiniteInventory Inventory;
        public EquipmentPanel EquipmentPanel;

        [SerializeField] CraftingWindow craftingWindow;
        [SerializeField] StatPanel statPanel;
        [SerializeField] ItemTooltip itemTooltip;
        [SerializeField] Image draggableItem;
        [SerializeField] DropItemArea dropItemArea;
        [SerializeField] QuestionDialog questionDialog;
        [SerializeField] ItemSaveManager itemSaveManager;

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
            Inventory.OnRigtClickEvent += InventoryRightClick;
            EquipmentPanel.OnRigtClickEvent += EquipmentPanelRightClick;

            //Pointer Enter
            Inventory.OnPointerEnterEvent += ShowTooltip;
            EquipmentPanel.OnPointerEnterEvent += ShowTooltip;
            craftingWindow.OnPointerEnterEvent += ShowTooltip;

            //Pointer Exit
            Inventory.OnPointerExitEvent += HideTooltip;
            EquipmentPanel.OnPointerExitEvent += HideTooltip;
             craftingWindow.OnPointerExitEvent += HideTooltip;

            //Begin Drag
            Inventory.OnBeginDragEvent += BeginDrag;
            EquipmentPanel.OnBeginDragEvent += BeginDrag;

            //End Drag
            Inventory.OnEndDragEvet += EndDrag;
            EquipmentPanel.OnEndDragEvet += EndDrag;

            //Drag
            Inventory.OnDragEvent += Drag;
            EquipmentPanel.OnDragEvent += Drag;

            //Drop
            Inventory.OnDropEvent += Drop;
            EquipmentPanel.OnDropEvent += Drop;
            dropItemArea.OnDropEvent += DropItemOutSideUI;

            itemSaveManager.LoadEquipment(this);
            itemSaveManager.LoadInventory(this);

        }

        private void OnDestroy()
        {
            itemSaveManager.SaveEquipment(this);
            itemSaveManager.SaveInventory(this);
        }
        private void InventoryRightClick(BaseItemSlot itemSlot)
        {
            if (itemSlot.Item is EquippableItem)
            {
                Equip((EquippableItem)itemSlot.Item);
            }
            else if (itemSlot.Item is UsableItem)
            {
                UsableItem usableItem = (UsableItem)itemSlot.Item;
                usableItem.Use(this);

                if (usableItem.IsConsumable)
                {
                    Inventory.RemoveItem(usableItem);
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
            if (itemTooltip.gameObject.activeSelf)
                itemTooltip.HideTooltip();
        }
        private void BeginDrag(BaseItemSlot itemSlot)
        {
            if (itemSlot.Item != null)
            {
                dragItemSlot = itemSlot;
                draggableItem.sprite = itemSlot.Item.Icon;
                draggableItem.transform.position = Input.mousePosition;
                draggableItem.gameObject.SetActive(true);

            }
        }
        private void Drag(BaseItemSlot itemSlot)
        {
            if (draggableItem != null)
                draggableItem.transform.position = Input.mousePosition;

        }
        private void EndDrag(BaseItemSlot itemSlot)
        {
            dragItemSlot = null;
            draggableItem.gameObject.SetActive(false);
        }
        private void Drop(BaseItemSlot dropItemSlot)
        {
            //Se arrastar um item com os dois botoes o sistem entende que a funcao ja foi feita ao soltar um dos botoes e caso nao existir nenhum item send arrastado quando soltar algum botao do mouse simplesmente retorna pq nao tem nada pra trocar de slot
            if (dragItemSlot == null) {
                Debug.Log("DRAG SLOT TA NULL!");
                return; }

            if (dropItemSlot.CanAddStack(dragItemSlot.Item))
            {
                Debug.Log("add stack!!");

                AddStacks(dropItemSlot);
            }
            else if (dropItemSlot.CanReceiveItem(dragItemSlot.Item) && dragItemSlot.CanReceiveItem(dropItemSlot.Item))
            {
                Debug.Log("Swap items");

                SwapItems(dropItemSlot);
            }
            else
            {
                Debug.Log("nenhum nem outro");

            }

            Debug.Log("----------------------");

        }
        private void DropItemOutSideUI()
        {
            if (dragItemSlot == null) return;

            questionDialog.Show();
            BaseItemSlot baseItemSlot = dragItemSlot;
            questionDialog.OnYesEvent += () =>DestroyItemInSlot(baseItemSlot);

        }

        private void DestroyItemInSlot(BaseItemSlot baseItemSlot)
        {
            baseItemSlot.Item.Destroy();
            baseItemSlot.Item = null;
        }
        private void AddStacks(BaseItemSlot dropItemSlot)
        {
            int numAddableStacks = dropItemSlot.Item.MaximumStacks - dropItemSlot.Amount;
            int stacksToAdd = Mathf.Min(numAddableStacks, dragItemSlot.Amount);

            dropItemSlot.Amount += stacksToAdd;
            dragItemSlot.Amount -= stacksToAdd;
        }
        private void SwapItems(BaseItemSlot dropItemSlot)
        {
            EquippableItem dragEquipItem = dragItemSlot.Item as EquippableItem;
            EquippableItem dropEquipItem = dropItemSlot.Item as EquippableItem;

            if (dropItemSlot is EquipmentSlot)
            {
                Debug.Log("DROP ITEM É EQUIPAVEL!");
                if (dragEquipItem != null) dragEquipItem.Equip(this);
                if (dropEquipItem != null) dropEquipItem.Unequip(this);
            }
            if (dragItemSlot is EquipmentSlot)
            {
                Debug.Log("DRAG ITEM É EQUIPAVEL!");
                Debug.Log(dragEquipItem.ItemName);
                if (dragEquipItem != null) dragEquipItem.Unequip(this);
                if (dropEquipItem != null) dropEquipItem.Equip(this);
            }
            statPanel.UpdateStatValues();

            Item draggedItem = dragItemSlot.Item;
            int draggedItemAmount = dragItemSlot.Amount;

            dragItemSlot.Item = dropItemSlot.Item;
            dragItemSlot.Amount = dropItemSlot.Amount;

            dropItemSlot.Item = draggedItem;
            dropItemSlot.Amount = draggedItemAmount;
        }
        public void Equip(EquippableItem item)
        {
            Debug.Log("EQUIPU!");
            if (Inventory.RemoveItem(item))
            {
                Debug.Log("REMOVEU ITEM INVETARIO");

                EquippableItem previousItem;
                if (EquipmentPanel.AddItem(item, out previousItem))
                {
                    if (previousItem != null)
                    {
                        Inventory.AddItem(previousItem);
                        previousItem.Unequip(this);
                        statPanel.UpdateStatValues();
                    }
                    item.Equip(this);
                    statPanel.UpdateStatValues();
                }
                else
                {
                    Debug.Log("ADD ITEM");
                    Inventory.AddItem(item);
                }
            }
        }
        public void Unequip(EquippableItem item)
        {
            Debug.Log("DESEQUIPU!");

            if (Inventory.CanAddItem(item) && EquipmentPanel.RemoveItem(item))
            {
                Debug.Log("REMOVEU EQUIP PANEL E ADD NO INVETARIO!!");
                item.Unequip(this);
                statPanel.UpdateStatValues();
                Inventory.AddItem(item);
            }
        }
        public void UpdateStatValues()
        {
            statPanel.UpdateStatValues();
        }
        private ItemContainer openItemContainer;
        private void TransferToItemContainer(BaseItemSlot itemSlot)
        {
            Item item = itemSlot.Item;
            if (item == null) return;
            if (openItemContainer.CanAddItem(item))
            {
                Inventory.RemoveItem(item);
                openItemContainer.AddItem(item);
            }
        }
        private void TransferToInventory(BaseItemSlot itemSlot)
        {
            Item item = itemSlot.Item;
            Debug.Log(item);
            if (item == null) return;
            if (Inventory.CanAddItem(item))
            {
                openItemContainer.RemoveItem(item);
                Inventory.AddItem(item);
            }
        }
        public void OpenItemContainer(ItemContainer itemContainer)
        {
            openItemContainer = itemContainer;
            Inventory.OnRigtClickEvent -= InventoryRightClick;
            Inventory.OnRigtClickEvent += TransferToItemContainer;
            itemContainer.OnRigtClickEvent += TransferToInventory;

            itemContainer.OnPointerEnterEvent += ShowTooltip;
            itemContainer.OnPointerExitEvent += HideTooltip;
            itemContainer.OnBeginDragEvent += BeginDrag;
            itemContainer.OnEndDragEvet += EndDrag;
            itemContainer.OnDragEvent += Drag;
            itemContainer.OnDropEvent += Drop;
        }
        public void CloseItemContainer(ItemContainer itemContainer)
        {
            openItemContainer = null;
            Inventory.OnRigtClickEvent += InventoryRightClick;
            Inventory.OnRigtClickEvent -= TransferToItemContainer;
            itemContainer.OnRigtClickEvent -= TransferToInventory;

            itemContainer.OnPointerEnterEvent -= ShowTooltip;
            itemContainer.OnPointerExitEvent -= HideTooltip;
            itemContainer.OnBeginDragEvent -= BeginDrag;
            itemContainer.OnEndDragEvet -= EndDrag;
            itemContainer.OnDragEvent -= Drag;
            itemContainer.OnDropEvent -= Drop;
        }
    }
}