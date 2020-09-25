using UnityEngine;
using System.Collections;
public class FloorLampSave : SaveObject
{
    public bool isActiveLight;
    private void Awake()
    {
        Load();
    }

    private void OnDestroy()
    {
        Save();
    }
}