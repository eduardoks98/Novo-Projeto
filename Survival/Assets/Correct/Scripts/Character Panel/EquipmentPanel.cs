using EKS.Characters.Panel;
using EKS.Items;
using System;
using System.Collections;
using UnityEngine;

namespace EKS.Panel
{
    public class EquipmentPanel : MonoBehaviour
    {
        [SerializeField] Transform equipmentParent;
        public EquipmentSlot[] EquipmentSlots;

        public event Action<BaseItemSlot> OnPointerEnterEvent;
        public event Action<BaseItemSlot> OnPointerExitEvent;
        public event Action<BaseItemSlot> OnRigtClickEvent;
        public event Action<BaseItemSlot> OnBeginDragEvent;
        public event Action<BaseItemSlot> OnEndDragEvet;
        public event Action<BaseItemSlot> OnDragEvent;
        public event Action<BaseItemSlot> OnDropEvent;
        private void Start()
        {
            for (int i = 0; i < EquipmentSlots.Length; i++)
            {
                EquipmentSlots[i].OnPointerEnterEvent += slot => { if (OnPointerEnterEvent != null) OnPointerEnterEvent(slot); };
                EquipmentSlots[i].OnPointerExitEvent += slot => { if (OnPointerExitEvent != null) OnPointerExitEvent(slot); };
                EquipmentSlots[i].OnRigtClickEvent += slot => { if (OnRigtClickEvent != null) OnRigtClickEvent(slot); };
                EquipmentSlots[i].OnBeginDragEvent += slot => { if (OnBeginDragEvent != null) OnBeginDragEvent(slot); };
                EquipmentSlots[i].OnEndDragEvet += slot => { if (OnEndDragEvet != null) OnEndDragEvet(slot); };
                EquipmentSlots[i].OnDragEvent += slot => { if (OnDragEvent != null) OnDragEvent(slot); };
                EquipmentSlots[i].OnDropEvent += slot => { if (OnDropEvent != null) OnDropEvent(slot); };
            }
        }
        public void OnValidate()
        {
            EquipmentSlots = equipmentParent.GetComponentsInChildren<EquipmentSlot>();
        }

        public bool AddItem(EquippableItem item, out EquippableItem previousItem)
        {
            for (int i = 0; i < EquipmentSlots.Length; i++)
            {
                if (EquipmentSlots[i].EquipmentType == item.EquipmentType)
                {
                    previousItem = (EquippableItem)EquipmentSlots[i].Item;
                    EquipmentSlots[i].Item = item;
                    return true;
                }
            }
            previousItem = null;
            return false;
        }

        public bool RemoveItem(EquippableItem item)
        {
            for (int i = 0; i < EquipmentSlots.Length; i++)
            {
                if (EquipmentSlots[i].Item == item)
                {
                    EquipmentSlots[i].Item = null;
                    return true;
                }
            }
            return false;
        }
    }
}