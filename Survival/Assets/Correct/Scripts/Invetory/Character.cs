using System.Collections;
using UnityEngine;

namespace Assets.Correct.Scripts.Invetory
{
    public class Character : MonoBehaviour
    {

        public CharacterStat Strength;
        public CharacterStat Vitality;
        public CharacterStat Intelligence;
        public CharacterStat Agility;


        [SerializeField] Inventory inventory;
        [SerializeField] EquipmentPanel equipmentPanel;
        [SerializeField] StatPanel statPanel;

        private void Awake()
        {
            statPanel.SetStats(Strength, Vitality, Intelligence, Agility);
            statPanel.UpdateStatValues();
            inventory.OnItemRightClickedEvent += EquipFromInventory;
            equipmentPanel.OnItemRightClickedEvent += UnequipFromInventory;
        }
        private void EquipFromInventory(Item item)
        {
            if (item is EquipableItem)
            {
                Equip((EquipableItem)item);
            }
        }
        private void UnequipFromInventory(Item item)
        {
            if (item is EquipableItem)
            {
                Unequip((EquipableItem)item);
            }
        }
        public void Equip(EquipableItem item)
        {
            if (inventory.RemoveItem(item))
            {
                EquipableItem previousItem;
                if (equipmentPanel.AddItem(item, out previousItem))
                {
                    if (previousItem != null)
                    {
                        inventory.AddItem(previousItem);
                        previousItem.Unequip(this);
                        statPanel.UpdateStatValues();
                    }
                    item.Equip(this);
                    statPanel.UpdateStatValues();
                }
                else
                {
                    inventory.AddItem(item);
                }
            }
        }

        public void Unequip(EquipableItem item)
        {
            if (!inventory.IsFull() && equipmentPanel.RemoveItem(item))
            {
                inventory.AddItem(item);
                item.Unequip(this);
                statPanel.UpdateStatValues();
            }
        }
    }
}