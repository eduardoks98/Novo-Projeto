using EKS.Items;
using UnityEngine;

namespace EKS.Panel
{
    public class Inventory : ItemContainer
    {
        //[FormerlySerializedAs("items")]
        [SerializeField] Item[] startingItems;
        [SerializeField] protected Transform itemsParent;
        protected override void OnValidate()
        {
            if (itemsParent != null)
            {
                itemsParent.GetComponentsInChildren<ItemSlot>(includeInactive: true, result: ItemSlots);
            }

            if (!Application.isPlaying)
            {
                SetStartingItems();
            }
        }
        protected override void Awake()
        {
            base.Awake();
            SetStartingItems();
        }

        public void SetStartingItems()
        {
            Clear();
            foreach (Item item in startingItems)
            {
                AddItem(item.GetCopy());
            }
        }

    }
}