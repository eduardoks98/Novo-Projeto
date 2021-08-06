
using UnityEngine;

public static class ItemSaveIO
{
    private static readonly string baseSavePath;

    static ItemSaveIO()
    {
        baseSavePath = Application.persistentDataPath;
    }
    public static void SaveItems(ItemContianerSaveData items, string fileName)
    {
        FileReadWrite.WriteToBinaryFile(baseSavePath+"/"+fileName+".dat", items);
    }

    public static ItemContianerSaveData LoadItems(string fileName)
    {
        string filePath = baseSavePath + "/" + fileName + ".dat";
        if (System.IO.File.Exists(filePath))
        {
            return FileReadWrite.ReadFromBinaryFile<ItemContianerSaveData>(filePath);
        }
        return null;
    }
}
