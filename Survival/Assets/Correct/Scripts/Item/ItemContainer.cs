
using EKS.Characters.Panel;
using EKS.Panel;
using System;
using UnityEngine;

namespace EKS.Items
{
    public class ItemContainer : MonoBehaviour, IItemContainer
    {
        [SerializeField]protected ItemSlot[] itemSlots;

        public event Action<BaseItemSlot> OnPointerEnterEvent;
        public event Action<BaseItemSlot> OnPointerExitEvent;
        public event Action<BaseItemSlot> OnRigtClickEvent;
        public event Action<BaseItemSlot> OnBeginDragEvent;
        public event Action<BaseItemSlot> OnEndDragEvet;
        public event Action<BaseItemSlot> OnDragEvent;
        public event Action<BaseItemSlot> OnDropEvent;

        protected virtual void OnValidate()
        {
            itemSlots = GetComponentsInChildren<ItemSlot>();
        }
        protected virtual void Start()
        {
            for (int i = 0; i < itemSlots.Length; i++)
            {
                itemSlots[i].OnPointerEnterEvent += slot => OnPointerEnterEvent(slot);
                itemSlots[i].OnPointerExitEvent += slot => OnPointerExitEvent(slot);
                itemSlots[i].OnRigtClickEvent += slot => OnRigtClickEvent(slot);
                itemSlots[i].OnBeginDragEvent += slot => OnBeginDragEvent(slot);
                itemSlots[i].OnEndDragEvet += slot => OnEndDragEvet(slot);
                itemSlots[i].OnDragEvent += slot => OnDragEvent(slot);
                itemSlots[i].OnDropEvent += slot => OnDropEvent(slot);
            }
        }
        public virtual bool CanAddItem(Item item, int amount = 1)
        {
            int freeSpaces = 0;

            foreach (ItemSlot itemSlot in itemSlots)
            {
                if (itemSlot.Item == null || itemSlot.Item.ID == item.ID)
                    freeSpaces += item.MaximumStacks - itemSlot.Amount;
            }
            return freeSpaces >= amount;
        }
        public virtual bool AddItem(Item item)
        {
            for (int i = 0; i < itemSlots.Length; i++)
            {
                if (itemSlots[i].CanAddStack(item))
                {

                    itemSlots[i].Item = item;
                    itemSlots[i].Amount++;
                    return true;
                }
            }

            for (int i = 0; i < itemSlots.Length; i++)
            {
                if (itemSlots[i].Item == null)
                {

                    itemSlots[i].Item = item;
                    itemSlots[i].Amount++;
                    return true;
                }
            }
            return false;
        }
        public virtual bool RemoveItem(Item item)
        {
            for (int i = 0; i < itemSlots.Length; i++)
            {
                if (itemSlots[i].Item == item)
                {
                    itemSlots[i].Amount--;
                    return true;
                }
            }
            return false;
        }

        public virtual Item RemoveItem(string itemID)
        {
            for (int i = 0; i < itemSlots.Length; i++)
            {
                Item item = itemSlots[i].Item;
                if (item != null && item.ID == itemID)
                {

                    itemSlots[i].Amount--;
                    return item;
                }
            }
            return null;
        }

        public bool ContainsItem(Item item)
        {

            for (int i = 0; i < itemSlots.Length; i++)
            {
                if (itemSlots[i].Item == item)
                {
                    return true;
                }
            }

            return false;
        }
        public virtual int ItemCount(string itemID)
        {
            int number = 0;
            for (int i = 0; i < itemSlots.Length; i++)
            {
                Item item = itemSlots[i].Item;
                if (item != null && item.ID == itemID)
                {
                    number += itemSlots[i].Amount;
                }
            }

            return number;
        }


        public void Clear()
        {
            for (int i = 0; i < itemSlots.Length; i++)
            {
                itemSlots[i].Item = null;
                itemSlots[i].Amount = 0;
            }
        }
    }
}