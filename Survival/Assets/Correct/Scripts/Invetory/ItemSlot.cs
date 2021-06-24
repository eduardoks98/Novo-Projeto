using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using Assets.Correct.Util;
using TMPro;

namespace Assets.Correct.Scripts.Invetory
{
    public class ItemSlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
    {
        [SerializeField] Image image;
        [SerializeField] TextMeshProUGUI amountText;
        public event Action<ItemSlot> OnPointerEnterEvent;
        public event Action<ItemSlot> OnPointerExitEvent;
        public event Action<ItemSlot> OnRigtClickEvent;
        public event Action<ItemSlot> OnBeginDragEvent;
        public event Action<ItemSlot> OnEndDragEvet;
        public event Action<ItemSlot> OnDragEvent;
        public event Action<ItemSlot> OnDropEvent;

        private Color normalColor = Color.white;
       
        private Color disabledColor = new Color(1, 1, 1, 0.2f);
        [SerializeField] private Sprite disabledSprite = null;

        private Item _item;
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
                amountText.enabled = _item != null && _item.MaximumStacks > 1 && _amount > 1 ;
                if (amountText.enabled)
                {
                    amountText.text = _amount.ToString();
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
            if (image == null)
                image = GetComponent<Image>();

            if(amountText == null)
            {
                amountText = GetComponent<TextMeshProUGUI>();
            }
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