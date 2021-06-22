using Assets.Correct.Scripts.Interfaces;
using Assets.Correct.Scripts.Invetory;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public struct ItemAmout
{
    public Item Item;
    [Range(1,999)]
    public int Amount;
}
[CreateAssetMenu]
public class CraftingRecipe : ScriptableObject
{
    public List<ItemAmout> Materials;
    public List<ItemAmout> Results;

    public bool CanCraft(IItemContainer itemContainer)
    {
        foreach (ItemAmout itemAmout in Materials)
        {
            if (itemContainer.ItemCount(itemAmout.Item.ID) < itemAmout.Amount)
            {
                return false;
            }
        }
        return true;
    }

    public void Craft(IItemContainer itemContainer)
    {
        if (CanCraft(itemContainer))
        {
            foreach (ItemAmout itemAmout in Materials)
            {
                itemContainer.RemoveItem(itemAmout.Item);
            }
            foreach (ItemAmout itemAmout in Results)
            {
                itemContainer.AddItem(itemAmout.Item);
            }
        }
    }
}
