using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SaveLoad : MonoBehaviour
{
    #region Singletone
    public static SaveLoad instance { get; private set; }
    public static SaveLoad Instance
    {
        get
        {
            if (!instance)
            {
                return new GameObject("SaveLoad").AddComponent<SaveLoad>();
            }
            else
            {
                return instance;
            }
        }
    }
    
    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }
    #endregion

    public bool IsNewGame { get; set; } = false;
}
