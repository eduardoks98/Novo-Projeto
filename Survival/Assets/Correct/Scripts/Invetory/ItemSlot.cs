using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using Assets.Correct.Util;
using TMPro;

namespace Assets.Correct.Scripts.Invetory
{
    public class ItemSlot : BaseItemSlot, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
    {
        public event Action<BaseItemSlot> OnBeginDragEvent;
        public event Action<BaseItemSlot> OnEndDragEvet;
        public event Action<BaseItemSlot> OnDragEvent;
        public event Action<BaseItemSlot> OnDropEvent;

        private Color dragColor = new Color(1, 1, 1, 0.5f);

        public override bool CanAddStack(Item item, int amount = 1)
        {
            return base.CanAddStack(item, amount) && Amount + amount <= item.MaximumStacks;
        }
        public override bool CanReceiveItem(Item item)
        {
            return true;
        }
        public void OnBeginDrag(PointerEventData eventData)
        {
            if (Item != null)
                image.color = dragColor;

            if (OnBeginDragEvent != null)
            {
                if (eventData != null && eventData.button == PointerEventData.InputButton.Left)
                    OnBeginDragEvent(this);
            }
        }
        public void OnEndDrag(PointerEventData eventData)
        {
            if (Item != null)
                image.color = normalColor;

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