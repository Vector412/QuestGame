using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : GenericSingletonClass<InputManager>
{
    public Action Activate = delegate { };
    public Action Deactivate = delegate { };



    public void Update()
    {
        ActivateInput();
        DestroyInput();
    }

    private void ActivateInput()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Activate();
        }
    }

    private void DestroyInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Deactivate();
        }
    }




}
