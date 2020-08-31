using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : Interactible
{
    BreakableWindow windows;
    public override void DoActivate()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("DoActivate");
            windows.breakWindow();
        }

    }
}
