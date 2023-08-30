using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public int last_score;

    public class Data
    {
        public Data()
        {
            max_score = 0;
        }

        public int max_score;
    }
    public Data data = new Data();

    void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
        DontDestroyOnLoad(gameObject);

        if (File.Exists(Application.persistentDataPath + "\\Data.json") == false)
        {
            File.Create(Application.persistentDataPath + "\\Data.json").Close();

            data.max_score = 0;
            string json_data = JsonUtility.ToJson(data);
            File.WriteAllText(Application.persistentDataPath + "\\Data.json", json_data);
        }
        else
        {
            string raw_data = File.ReadAllText(Application.persistentDataPath + "\\Data.json");
            data = JsonUtility.FromJson<Data>(raw_data);
        }
    }

    public void SaveData(int current_score)
    {
        last_score = current_score;

        if (current_score > data.max_score)
        {
            data.max_score = current_score;
            string json_data = JsonUtility.ToJson(data);
            File.WriteAllText(Application.persistentDataPath + "\\Data.json", json_data);
        }
    }
}
