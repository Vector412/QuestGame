using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Safe : Interactible 
{
    [SerializeField] GameObject showSafe;
   



    public override void DoActivate()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            showSafe.gameObject.SetActive(true);
           


        }
    }

    public void Open()
    {
        Debug.Log("Open");
        Collider collider = GetComponent<Collider>();
        collider.enabled = false;
        ClearHint();
        Debug.Log("Off");

    }

    public void Close()
    {
        Debug.Log("Close");
    }
    
    

  





}
