using UnityEngine;
using System.Collections;

public class SaveObject : MonoBehaviour
{
    public string path;
    public void Save()
    {
        var text = JsonUtility.ToJson(this);
        Debug.LogWarning(text);
        PlayerPrefs.SetString(path, text);
    }
    public void Load()
    {
        if (!SaveLoad.Instance.IsNewGame)
        {
            var text = PlayerPrefs.GetString(path);
            Debug.LogWarning(text);
            if (text != "")
            {
                JsonUtility.FromJsonOverwrite(text, this);
            }
        }
    }
    private void OnEnable()
    {
        Load();
    }
    private void OnDisable()
    {
        Save();
    }
}