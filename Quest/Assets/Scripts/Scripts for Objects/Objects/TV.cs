using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV : Interactible, IDestructible
{
    public void DestroyObjects()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Destroy(gameObject);
        }
      
    }
    public override void DoActivate()
    {
        Debug.Log("Activate TV");
    }
}
