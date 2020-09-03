using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorLamp : Interactible, IDestructible
{
    [SerializeField] GameObject light ;

    [SerializeField] bool isActiveLight;


    public void Start()
    {
        if (isActiveLight)
        {
            light.gameObject.SetActive(true);
            isActiveLight = false;

        }
        else
        {
            light.gameObject.SetActive(false);
            isActiveLight = true;
        }
    }
   
    public override void DoActivate()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {       
            if (!isActiveLight)
            {
                OffLinght();
            }
            else
            {
                OnLight();
            }

        }
    }

    public void OffLinght()
    {
        light.gameObject.SetActive(false);
        isActiveLight = true;
    }
    public void OnLight()
    {
        light.gameObject.SetActive(true);
        isActiveLight = false;
    }

    public void DestroyObjects()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(gameObject);
        }
    }
}
