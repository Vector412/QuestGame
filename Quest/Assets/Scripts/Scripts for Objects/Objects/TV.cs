using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV : Interactible, IDestructible
{
    public void DestroyObjects()
    {
        Destroy(gameObject);
    }
    public override void DoActivate()
    {
        Debug.Log("Activate TV");
    }
}
