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
        [SerializeField] EquipmentSlot[] equipmentSlots;
        public event Action<BaseItemSlot> OnPointerEnterEvent;
        public event Action<BaseItemSlot> OnPointerExitEvent;
        public event Action<BaseItemSlot> OnRigtClickEvent;
        public event Action<BaseItemSlot> OnBeginDragEvent;
        public event Action<BaseItemSlot> OnEndDragEvet;
        public event Action<BaseItemSlot> OnDragEvent;
        public event Action<BaseItemSlot> OnDropEvent;
        private void Start()
        {
            for (int i = 0; i < equipmentSlots.Length; i++)
            {
                equipmentSlots[i].OnPointerEnterEvent += slot => OnPointerEnterEvent(slot);
                equipmentSlots[i].OnPointerExitEvent += slot => OnPointerExitEvent(slot);
                equipmentSlots[i].OnRigtClickEvent +=  slot =>OnRigtClickEvent(slot);
                equipmentSlots[i].OnBeginDragEvent += slot => OnBeginDragEvent(slot);
                equipmentSlots[i].OnEndDragEvet += slot => OnEndDragEvet(slot);
                equipmentSlots[i].OnDragEvent += slot => OnDragEvent(slot);
                equipmentSlots[i].OnDropEvent += slot => OnDropEvent(slot);
            }
        }
        public void OnValidate()
        {
            equipmentSlots = equipmentParent.GetComponentsInChildren<EquipmentSlot>();
        }

        public bool AddItem(EquippableItem item, out EquippableItem previousItem)
        {
            for (int i = 0; i < equipmentSlots.Length; i++)
            {
                if (equipmentSlots[i].EquipmentType == item.EquipmentType)
                {
                    previousItem = (EquippableItem)equipmentSlots[i].Item;
                    equipmentSlots[i].Item = item;
                    return true;
                }
            }
            previousItem = null;
            return false;
        }

        public bool RemoveItem(EquippableItem item)
        {
            for (int i = 0; i < equipmentSlots.Length; i++)
            {
                if (equipmentSlots[i].Item == item)
                {
                    equipmentSlots[i].Item = null;
                    return true;
                }
            }
            return false;
        }
    }
}