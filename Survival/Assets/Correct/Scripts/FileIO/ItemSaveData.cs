using System;

[Serializable]
public class ItemSlotSaveData
{
    public string ItemID;
    public int Amount;
    public ItemSlotSaveData(string id, int amount)
    {
        ItemID = id;
        Amount = amount;
    }
}
[Serializable]
public class ItemContianerSaveData
{
    public ItemSlotSaveData[] SavedSlots;
    public ItemContianerSaveData(int numItems)
    {
        SavedSlots = new ItemSlotSaveData[numItems];
    }
}