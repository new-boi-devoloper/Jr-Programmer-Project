using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public Color TeamColor;

    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        DontDestroyOnLoad(gameObject);

        LoadColorFromFiles();
    }

    [System.Serializable]
    class SaveData
    {
        public Color TeamColor;
    }

    public void SaveColorToFiles()
    {
        SaveData myData = new SaveData();
        myData.TeamColor = TeamColor;

        string json = JsonUtility.ToJson(myData);
        File.WriteAllText(Application.persistentDataPath + "/savecolor.json", json);
    }

    public void LoadColorFromFiles()
    {
        string path = Application.persistentDataPath + "/savecolor.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData myData = JsonUtility.FromJson<SaveData>(json);

            TeamColor = myData.TeamColor;
        }
        else
        {
            Debug.Log("÷вет не был сохранЄн, либо не был выбран");
        }
    }
}
