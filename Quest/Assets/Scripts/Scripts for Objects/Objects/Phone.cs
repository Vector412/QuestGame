using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : Interactible
{
    [SerializeField] GameObject phone;
    public override void DoActivate()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            phone.gameObject.SetActive(true);
             
        }
    }
}
