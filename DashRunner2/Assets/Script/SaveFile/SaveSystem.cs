using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveSystem
{
    public static void SavePlayer(PlayerTest player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Player.ffn";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/Player.ffn";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;

            stream.Close();
            return data;
      
        }else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
        
    }

    public static void DeleteData()
    {
        string path = Application.persistentDataPath + "/Player.ffn";
        if(File.Exists(path))
        {
            File.Delete(path);
            Debug.Log("File deleted");
        }else
        {
            Debug.LogError("Save file not found in " + path);

        }
    }
}