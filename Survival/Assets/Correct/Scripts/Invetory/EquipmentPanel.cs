using System;
using System.Collections;
using UnityEngine;

namespace Assets.Correct.Scripts.Invetory
{
    public class EquipmentPanel : MonoBehaviour
    {
        [SerializeField] Transform equipmentParent;
        [SerializeField] EquipmentSlot[] equipmentSlots;
        public event Action<Item> OnItemRightClickedEvent;
        private void Awake()
        {
            for (int i = 0; i < equipmentSlots.Length; i++)
            {
                equipmentSlots[i].OnRigtClickEvent += OnItemRightClickedEvent;
            }
        }
        public void OnValidate()
        {
            equipmentSlots = equipmentParent.GetComponentsInChildren<EquipmentSlot>();
        }

        public bool AddItem(EquipableItem item, out EquipableItem previousItem)
        {
            for (int i = 0; i < equipmentSlots.Length; i++)
            {
                if (equipmentSlots[i].EquipmentType == item.EquipmentType)
                {
                    previousItem = (EquipableItem)equipmentSlots[i].Item;
                    equipmentSlots[i].Item = item;
                    return true;
                }
            }
            previousItem = null;
            return false;
        }

        public bool RemoveItem(EquipableItem item)
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