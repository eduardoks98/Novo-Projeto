﻿using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using EKS.Items;

namespace EKS.Characters.Panel
{
    public class BaseItemSlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] protected Image image;
        [SerializeField] protected TextMeshProUGUI amountText;
        public event Action<BaseItemSlot> OnPointerEnterEvent;
        public event Action<BaseItemSlot> OnPointerExitEvent;
        public event Action<BaseItemSlot> OnRigtClickEvent;

        protected Color normalColor = Color.white;
        protected Color disabledColor = new Color(1, 1, 1, 0.2f);

        [SerializeField] private Sprite disabledSprite = null;

        protected Item _item;
        public Item Item
        {
            get => _item; set
            {

                _item = value;
                if (_item == null)
                {
                    if (disabledSprite != null)
                        image.sprite = disabledSprite;
                    image.color = disabledColor;
                }
                else
                {
                    image.sprite = _item.Icon;
                    image.color = normalColor;
                }
            }
        }
        private int _amount;
        public int Amount
        {
            get { return _amount; }
            set
            {
                _amount = value;
                if (_amount < 0) _amount = 0;
                if (_amount == 0 && Item != null) Item = null;

                if (amountText != null)
                {
                    amountText.enabled = _item != null && _amount > 1;
                    if (amountText.enabled)
                    {
                        amountText.text = _amount.ToString();
                    }
                }
            }
        }
        protected virtual void OnValidate()
        {
            if (image == null)
                image = GetComponent<Image>();

            if (amountText == null)
            {
                amountText = GetComponent<TextMeshProUGUI>();
            }
        }
        public virtual bool CanAddStack(Item item, int amount = 1)
        {
            return Item != null && Item.ID == Item.ID;
        }
        public virtual bool CanReceiveItem(Item item)
        {
            return false;
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


    }
}
