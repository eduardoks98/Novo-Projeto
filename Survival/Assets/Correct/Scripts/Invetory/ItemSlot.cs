using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

namespace Assets.Correct.Scripts.Invetory
{
    public class ItemSlot : MonoBehaviour, IPointerClickHandler
    {
        private Item _item;
        [SerializeField]Image Image;

        public event Action<Item> OnRigtClickEvent;
        public Item Item { get => _item; set
            {

                _item = value;
                if(_item == null)
                {
                    Image.enabled = false;
                }
                else
                {
                    Image.sprite = _item.Icon;
                    Image.enabled = true;
                }
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if(eventData!=null && eventData.button == PointerEventData.InputButton.Right)
            {
                Debug.Log("Entrou");
                if (Item !=null && OnRigtClickEvent != null)
                {
                    
                    OnRigtClickEvent(Item);
                }
            }
        }

        protected virtual void OnValidate()
        {
            if (Image == null)
                 Image = GetComponent<Image>();
        }
    }
}