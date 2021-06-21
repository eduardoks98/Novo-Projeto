using System.Collections;
using UnityEngine;

namespace Assets.Correct.Scripts.Invetory
{
    public class EquipmentSlot : ItemSlot
    {
        public EquipmentType EquipmentType;

        protected override void OnValidate()
        {
            base.OnValidate();
            gameObject.name = EquipmentType.ToString() + " Slot";
        }

    }
}