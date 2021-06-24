using EKS.Characters.Panel;
using EKS.Items;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace EKS.Panel
{
    public class Inventory : ItemContainer
    {
        //[FormerlySerializedAs("items")]
        [SerializeField] List<Item> startingItems;
        [SerializeField] Transform itemsParent;

        public event Action<BaseItemSlot> OnPointerEnterEvent;
        public event Action<BaseItemSlot> OnPointerExitEvent;
        public event Action<BaseItemSlot> OnRigtClickEvent;
        public event Action<BaseItemSlot> OnBeginDragEvent;
        public event Action<BaseItemSlot> OnEndDragEvet;
        public event Action<BaseItemSlot> OnDragEvent;
        public event Action<BaseItemSlot> OnDropEvent;
        private void Start()
        {
            for (int i = 0; i < itemSlots.Length; i++)
            {
                itemSlots[i].OnPointerEnterEvent += slot => OnPointerEnterEvent(slot);
                itemSlots[i].OnPointerExitEvent += slot => OnPointerExitEvent(slot);
                itemSlots[i].OnRigtClickEvent += slot => OnRigtClickEvent(slot);
                itemSlots[i].OnBeginDragEvent += slot => OnBeginDragEvent(slot);
                itemSlots[i].OnEndDragEvet += slot => OnEndDragEvet(slot);
                itemSlots[i].OnDragEvent += slot => OnDragEvent(slot);
                itemSlots[i].OnDropEvent +=  slot =>OnDropEvent(slot);
            }
            SetStartingItems();
        }

        private void OnValidate()
        {
            if (itemsParent != null)
                itemSlots = itemsParent.GetComponentsInChildren<ItemSlot>();

            SetStartingItems();
        }

        public void SetStartingItems()
        {
            Clear();
            for (int i = 0; i < startingItems.Count; i++)
            {
                AddItem(startingItems[i].GetCopy());
            }
        }

    }
}