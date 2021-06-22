﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using Assets.Correct.Util;

namespace Assets.Correct.Scripts.Invetory
{
    public class ItemSlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
    {
        [SerializeField] Image Image;

        public event Action<ItemSlot> OnPointerEnterEvent;
        public event Action<ItemSlot> OnPointerExitEvent;
        public event Action<ItemSlot> OnRigtClickEvent;
        public event Action<ItemSlot> OnBeginDragEvent;
        public event Action<ItemSlot> OnEndDragEvet;
        public event Action<ItemSlot> OnDragEvent;
        public event Action<ItemSlot> OnDropEvent;

        private Color normalColor = Color.white;
        [SerializeField]
        private Color disabledColor = new Color(1, 1, 1, 0.8F);

        private Item _item;
        public Item Item
        {
            get => _item; set
            {

                _item = value;
                if (_item == null)
                {
                    if(GameAssets.i.DisabledSlot != null)
                    Image.sprite = GameAssets.i.DisabledSlot;
                    Image.color = disabledColor;
                }
                else
                {
                    Image.sprite = _item.Icon;
                    Image.color = normalColor;
                }
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData != null && eventData.button == PointerEventData.InputButton.Right)
            {
                if (OnRigtClickEvent != null)
                {
                    OnRigtClickEvent(this);
                }
            }
        }

        protected virtual void OnValidate()
        {
            if (Image == null)
                Image = GetComponent<Image>();

        }

        public virtual bool CanReceiveItem(Item item)
        {
            return true;
        }
        public void OnPointerEnter(PointerEventData eventData)
        {
            if (OnPointerEnterEvent != null)
            {
                OnPointerEnterEvent(this);
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (OnPointerExitEvent != null)
            {
                OnPointerExitEvent(this);
            }
        }
        public void OnBeginDrag(PointerEventData eventData)
        {

            if (OnBeginDragEvent != null)
            {
                if (eventData != null && eventData.button == PointerEventData.InputButton.Left)
                    OnBeginDragEvent(this);
            }
        }
        public void OnEndDrag(PointerEventData eventData)
        {
            if (OnEndDragEvet != null)
            {
                OnEndDragEvet(this);
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (OnDragEvent != null)
            {
                OnDragEvent(this);
            }
        }

        public void OnDrop(PointerEventData eventData)
        {
            if (OnDropEvent != null)
            {
                OnDropEvent(this);
            }
        }


    }
}