using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Interactible
{
    [SerializeField] GameObject screenKey;
    [SerializeField] GameObject key;
    public override void DoActivate()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            screenKey.SetActive(true);
            Destroy(key);
          
           
        }
    }


}
