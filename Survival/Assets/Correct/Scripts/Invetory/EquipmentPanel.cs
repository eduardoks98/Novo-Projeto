using System;
using System.Collections;
using UnityEngine;

namespace Assets.Correct.Scripts.Invetory
{
    public class EquipmentPanel : MonoBehaviour
    {
        [SerializeField] Transform equipmentParent;
        [SerializeField] EquipmentSlot[] equipmentSlots;
        public event Action<ItemSlot> OnPointerEnterEvent;
        public event Action<ItemSlot> OnPointerExitEvent;
        public event Action<ItemSlot> OnRigtClickEvent;
        public event Action<ItemSlot> OnBeginDragEvent;
        public event Action<ItemSlot> OnEndDragEvet;
        public event Action<ItemSlot> OnDragEvent;
        public event Action<ItemSlot> OnDropEvent;
        private void Start()
        {
            for (int i = 0; i < equipmentSlots.Length; i++)
            {
                equipmentSlots[i].OnPointerEnterEvent += OnPointerEnterEvent;
                equipmentSlots[i].OnPointerExitEvent += OnPointerExitEvent;
                equipmentSlots[i].OnRigtClickEvent += OnRigtClickEvent;
                equipmentSlots[i].OnBeginDragEvent += OnBeginDragEvent;
                equipmentSlots[i].OnEndDragEvet += OnEndDragEvet;
                equipmentSlots[i].OnDragEvent += OnDragEvent;
                equipmentSlots[i].OnDropEvent += OnDropEvent;
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