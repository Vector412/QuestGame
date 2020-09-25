using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LocalizationManager : MonoBehaviour
{

    public static LocalizationManager instance;
    private Dictionary<string, string> localizedText = new Dictionary<string, string>();
    private string missingTextString = "Localized text isn't found";



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        LoadLocalizedText("localizedText_en.json");

    }
    void Start()
    {



        DontDestroyOnLoad(gameObject);
       
    }


    public void LoadLocalizedText(string fileName)
    {
        localizedText = new Dictionary<string, string>();
        string filePath = Path.Combine(Application.streamingAssetsPath, fileName);
        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            LocalizationData loadedData = JsonUtility.FromJson<LocalizationData>(dataAsJson);
            for (int i = 0; i < loadedData.items.Length; i++)
            {
                localizedText.Add(loadedData.items[i].key, loadedData.items[i].value);
            }
            Debug.Log("Data loaded, dictionary contains: " + localizedText.Count + "entries");
            Refresh();
        }
        else
        {
            Debug.LogError("Cannot find file!");
        }

    }
    public void Refresh()
    {
        var items = FindObjectsOfType<LocalizedText>();
        foreach (var item in items)
        {
            item.Load();
        }
    }
    public string GetLocalizedValue(string key)
    {
        string result = missingTextString;
        if (localizedText.ContainsKey(key))
        {
            result = localizedText[key];
        }
        return result;
    }
}
