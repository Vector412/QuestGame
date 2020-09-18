using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorLamp : Interactible, IDestructible
{
    [SerializeField] GameObject light ;
    [SerializeField] public AudioClip destroyLamp, onLight;

    [SerializeField] bool isActiveLight;


    public void Start()
    {
        if (isActiveLight)
        {
            Light(true, false, onLight);
        }
        else
        {
            Light(false, true, onLight);
        }
    }
   
    public override void DoActivate()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {       
            if (!isActiveLight)
            {
                Light(false, true, onLight);
            }
            else
            {
                Light(true,false, onLight);
            }

        }
    }

    public void Light(bool isGameObjActive, bool isLight, AudioClip audioClip)
    {
        light.gameObject.SetActive(isGameObjActive);
        isActiveLight = isLight;
        GetComponent<AudioSource>().PlayOneShot(audioClip);
    }


    public void DestroyObjects()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           
            GetComponent<AudioSource>().PlayOneShot(destroyLamp);
            Collider collider = GetComponent<Collider>();
            collider.enabled = false;
            ClearHint();
            Destroy(gameObject, 0.5f);
          
        }
    }
}
