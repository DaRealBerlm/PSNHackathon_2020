using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public static class SaveSystem
{
    private static string path = Path.Combine(Application.persistentDataPath, "data.berlm");

    public static void SaveData(DataFrame data)
    {
        if (data == null)
        {
            Debug.LogError("Data given is null, I messed up"); // Should never come
            return;
        }

        BinaryFormatter formatter = new BinaryFormatter();

        using (FileStream stream = new FileStream(path, FileMode.Create))
        {
            formatter.Serialize(stream, data);
        }
    }

    public static DataFrame LoadData()
    {
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                try
                {
                    DataFrame data = (DataFrame) formatter.Deserialize(stream);
                    return data;
                }
                catch (Exception e)
                {
                    Debug.Log($"[ERROR]: {e}");
                }
            }
        }

        Debug.LogError($"Save file not found at {path}");
        return null;
    }
}
