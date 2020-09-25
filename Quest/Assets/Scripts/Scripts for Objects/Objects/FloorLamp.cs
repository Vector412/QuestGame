using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(FloorLampSave))]
public class FloorLamp : Interactible, IDestructible
{
    [SerializeField] public new GameObject light;
    [SerializeField] public AudioClip destroyLamp, onLight;
    FloorLampSave save;
    private void Awake()
    {
        save = GetComponent<FloorLampSave>();
        
    }
    public void Start()
    {

        if (!save.isActiveLight)
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
        if (!save.isActiveLight)
        {
            Light(false, true, onLight);
        }
        else
        {
            Light(true, false, onLight);
        }
    }

    public void Light(bool isGameObjActive, bool isLight, AudioClip audioClip)
    {
        light.gameObject.SetActive(isGameObjActive);
        save.isActiveLight = isLight;
        GetComponent<AudioSource>().PlayOneShot(audioClip);
    }


    public void DestroyObjects()
    {

        GetComponent<AudioSource>().PlayOneShot(destroyLamp);
        Collider collider = GetComponent<Collider>();
        collider.enabled = false;
        ClearHint();
        Destroy(gameObject, 0.5f);

    }
}
