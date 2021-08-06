
using EKS.Characters.Panel;
using EKS.Panel;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace EKS.Items
{
    public class ItemContainer : MonoBehaviour, IItemContainer
    {
        public List<ItemSlot> ItemSlots;

        public event Action<BaseItemSlot> OnPointerEnterEvent;
        public event Action<BaseItemSlot> OnPointerExitEvent;
        public event Action<BaseItemSlot> OnRigtClickEvent;
        public event Action<BaseItemSlot> OnBeginDragEvent;
        public event Action<BaseItemSlot> OnEndDragEvet;
        public event Action<BaseItemSlot> OnDragEvent;
        public event Action<BaseItemSlot> OnDropEvent;

        protected virtual void OnValidate()
        {
            GetComponentsInChildren<ItemSlot>(includeInactive:true, result:ItemSlots);
        }
        protected virtual void Awake()
        {
            for (int i = 0; i < ItemSlots.Count; i++)
            {
                AddListenerToSlot(i);
            }
        }

        public virtual void AddListenerToSlot(int i)
        {
            ItemSlots[i].OnPointerEnterEvent += slot => { if (OnPointerEnterEvent != null) OnPointerEnterEvent(slot); };
            ItemSlots[i].OnPointerExitEvent += slot => { if (OnPointerExitEvent != null) OnPointerExitEvent(slot); };
            ItemSlots[i].OnRigtClickEvent += slot => { if (OnRigtClickEvent != null) OnRigtClickEvent(slot); };
            ItemSlots[i].OnBeginDragEvent += slot => { if (OnBeginDragEvent != null) OnBeginDragEvent(slot); };
            ItemSlots[i].OnEndDragEvet += slot => { if (OnEndDragEvet != null) OnEndDragEvet(slot); };
            ItemSlots[i].OnDragEvent += slot => { if (OnDragEvent != null) OnDragEvent(slot); };
            ItemSlots[i].OnDropEvent += slot => { if (OnDropEvent != null) OnDropEvent(slot); };
        }
        public virtual bool CanAddItem(Item item, int amount = 1)
        {
            int freeSpaces = 0;

            foreach (ItemSlot itemSlot in ItemSlots)
            {
                if (itemSlot.Item == null || itemSlot.Item.ID == item.ID)
                    freeSpaces += item.MaximumStacks - itemSlot.Amount;
            }

            return freeSpaces >= amount;
        }
        public virtual bool AddItem(Item item)
        {
            for (int i = 0; i < ItemSlots.Count; i++)
            {
                if (ItemSlots[i].CanAddStack(item))
                {

                    ItemSlots[i].Item = item;
                    ItemSlots[i].Amount++;
                    AddListenerToSlot(i);
                    return true;
                }
            }

            for (int i = 0; i < ItemSlots.Count; i++)
            {
                if (ItemSlots[i].Item == null)
                {

                    ItemSlots[i].Item = item;
                    ItemSlots[i].Amount++;
                    AddListenerToSlot(i);
                    return true;
                }
            }
            return false;
        }
        public virtual bool RemoveItem(Item item)
        {
            for (int i = 0; i < ItemSlots.Count; i++)
            {
                if (ItemSlots[i].Item == item)
                {
                    ItemSlots[i].Amount--;
                    return true;
                }
            }
            return false;
        }

        public virtual Item RemoveItem(string itemID)
        {
            for (int i = 0; i < ItemSlots.Count; i++)
            {
                Item item = ItemSlots[i].Item;
                if (item != null && item.ID == itemID)
                {

                    ItemSlots[i].Amount--;
                    return item;
                }
            }
            return null;
        }

        public bool ContainsItem(Item item)
        {

            for (int i = 0; i < ItemSlots.Count; i++)
            {
                if (ItemSlots[i].Item == item)
                {
                    return true;
                }
            }

            return false;
        }
        public virtual int ItemCount(string itemID)
        {
            int number = 0;
            for (int i = 0; i < ItemSlots.Count; i++)
            {
                Item item = ItemSlots[i].Item;
                if (item != null && item.ID == itemID)
                {
                    number += ItemSlots[i].Amount;
                }
            }

            return number;
        }


        public void Clear()
        {
            for (int i = 0; i < ItemSlots.Count; i++)
            {
                ItemSlots[i].Item = null;
                ItemSlots[i].Amount = 0;
            }
        }
    }
}