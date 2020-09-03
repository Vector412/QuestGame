using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorLamp : Interactible, IDestructible
{
    [SerializeField] GameObject light ;

    private bool isActiveLight = true;
    public void DestroyObjects()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(gameObject);
        }
    }
    public override void DoActivate()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
          
            Debug.Log("Light");
            if (isActiveLight)
            {
                light.gameObject.SetActive(true);
                Debug.Log("Active");
                isActiveLight = false;
            }
            else
            {
                light.gameObject.SetActive(false);
                Debug.Log("False");
                isActiveLight = true;
            }


        }

      
    }
}
