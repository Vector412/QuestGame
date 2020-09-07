using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV : Interactible, IDestructible
{
    [SerializeField] GameObject tv;
    [SerializeField] public AudioClip destroyTv, turnOn;
    
    private bool isTurnOn = true;
    public void DestroyObjects()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<AudioSource>().PlayOneShot(destroyTv);
            Collider collider = GetComponent<Collider>();
            collider.enabled = false;
            ClearHint();
            tv.gameObject.SetActive(false);


        }
      
    }
    public override void DoActivate()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!isTurnOn)
            {
                tv.gameObject.SetActive(false);
                isTurnOn = true;
                GetComponent<AudioSource>().PlayOneShot(turnOn);
            }
            else
            {
                tv.gameObject.SetActive(true);
                isTurnOn = false;
                GetComponent<AudioSource>().PlayOneShot(turnOn);
            }
           
        }
    }
}
