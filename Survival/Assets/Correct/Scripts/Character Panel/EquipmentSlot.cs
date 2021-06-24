﻿

using EKS.Items;
using EKS.Items.Equipment;

namespace EKS.Panel
{
    public class EquipmentSlot : ItemSlot
    {
        public EquipmentType EquipmentType;

        protected override void OnValidate()
        {
            base.OnValidate();
            gameObject.name = EquipmentType.ToString() + " Slot";
        }

        public override bool CanReceiveItem(Item item)
        {
            if (item == null)
                return true;

            EquippableItem equippableItem = item as EquippableItem;
            return equippableItem != null && equippableItem.EquipmentType == EquipmentType;
        }

    }
}