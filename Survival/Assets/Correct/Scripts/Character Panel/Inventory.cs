using EKS.Items;
using UnityEngine;

namespace EKS.Panel
{
    public class Inventory : ItemContainer
    {
        //[FormerlySerializedAs("items")]
        [SerializeField] Item[] startingItems;
        [SerializeField] Transform itemsParent;
        protected override void OnValidate()
        {
            if (itemsParent != null)
                itemSlots = itemsParent.GetComponentsInChildren<ItemSlot>(includeInactive:true);

            if (!Application.isPlaying)
            {
                SetStartingItems();
            }
        }
        protected override void Start()
        {
            base.Start();
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