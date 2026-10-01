using System.IO;
using UnityEngine;

public static class SaveSystem
{
    private static string SaveDirectory =>
        Path.Combine(Application.dataPath, "SaveData");

    public static void Save(int slotNumber)
    {
        SaveData data = new SaveData();

        string savePath = Path.Combine(
            SaveDirectory,
            "SaveData" + slotNumber + ".json"
        );

        string json = JsonUtility.ToJson(data, true);

        Directory.CreateDirectory(SaveDirectory);
        File.WriteAllText(savePath, json);

        Debug.Log("スロット" + slotNumber + "にセーブしました: " + savePath);
    }

    public static SaveData Load(int slotNumber)
    {
        string savePath = Path.Combine(
            SaveDirectory,
            "SaveData" + slotNumber + ".json"
        );

        if (!File.Exists(savePath))
        {
            Debug.Log("セーブデータがありません。");
            return null;
        }

        string json = File.ReadAllText(savePath);

        SaveData data = JsonUtility.FromJson<SaveData>(json);

        return data;
    }
}

[System.Serializable]
public class SaveData
{
}