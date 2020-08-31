using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorLamp : Interactible, IDestructible
{
    public void DestroyObjects()
    {
        Destroy(gameObject);
    }
    public override void DoActivate()
    {
        Debug.Log("Activate Lamp");
    }
}
