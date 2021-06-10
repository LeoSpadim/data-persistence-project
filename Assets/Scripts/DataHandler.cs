using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataHandler : MonoBehaviour
{
    public static DataHandler Instance;

    public SaveData dataToSave;
    public string bestScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadFile();
    }

    [System.Serializable]
    public class SaveData
    {
        public string Name;
        public int BestScore;
    }

    public void SaveFile()
    {
        string json = JsonUtility.ToJson(dataToSave);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadFile()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            dataToSave = JsonUtility.FromJson<SaveData>(json);
        }

        bestScore = $"Best Score: {dataToSave.Name}: {dataToSave.BestScore}";
    }
}
