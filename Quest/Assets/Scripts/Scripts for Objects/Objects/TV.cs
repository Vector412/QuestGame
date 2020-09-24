using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV : Interactible, IDestructible
{
    [SerializeField] GameObject tv;
    [SerializeField] AudioClip destroyTv, turnOn;

    private bool isTurnOn = true;


    public void DestroyObjects()
    {
        GetComponent<AudioSource>().PlayOneShot(destroyTv);
        Collider collider = GetComponent<Collider>();
        collider.enabled = false;
        ClearHint();
        tv.gameObject.SetActive(false);
    }
    public override void DoActivate()
    {
        tv.gameObject.SetActive(isTurnOn);
        isTurnOn = !isTurnOn;
        GetComponent<AudioSource>().PlayOneShot(turnOn);
    }
}
