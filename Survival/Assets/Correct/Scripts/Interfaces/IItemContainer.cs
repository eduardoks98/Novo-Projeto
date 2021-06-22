﻿using Assets.Correct.Scripts.Invetory;
namespace Assets.Correct.Scripts.Interfaces
{
    public interface IItemContainer 
    {
        bool ContainsItem(Item item);
        int ItemCount(string itemID);
        Item RemoveItem(string itemID);
        bool RemoveItem(Item item);
        bool AddItem(Item item);
        bool IsFull();
    }
}