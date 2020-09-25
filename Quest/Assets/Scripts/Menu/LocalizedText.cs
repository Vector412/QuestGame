using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalizedText : MonoBehaviour
{
    public string key;

    private void Start()
    {
        Load();
    }
    public void Load()
    {
        Text text = GetComponent<Text>();
        print(LocalizationManager.instance);
        text.text = LocalizationManager.instance.GetLocalizedValue(key);
    }

}
