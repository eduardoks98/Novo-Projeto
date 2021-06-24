﻿using Assets.Correct.Scripts.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Assets.Correct.Scripts.Invetory
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
                itemSlots[i].OnPointerEnterEvent += OnPointerEnterEvent;
                itemSlots[i].OnPointerExitEvent += OnPointerExitEvent;
                itemSlots[i].OnRigtClickEvent += OnRigtClickEvent;
                itemSlots[i].OnBeginDragEvent += OnBeginDragEvent;
                itemSlots[i].OnEndDragEvet += OnEndDragEvet;
                itemSlots[i].OnDragEvent += OnDragEvent;
                itemSlots[i].OnDropEvent += OnDropEvent;
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
            int i = 0;
            for (; i < startingItems.Count && i < itemSlots.Length; i++)
            {
                itemSlots[i].Item = startingItems[i].GetCopy();
                itemSlots[i].Amount = 1;
            }

            for (; i < itemSlots.Length; i++)
            {
                itemSlots[i].Item = null;
                itemSlots[i].Amount = 0;
            }
        }

    }
}