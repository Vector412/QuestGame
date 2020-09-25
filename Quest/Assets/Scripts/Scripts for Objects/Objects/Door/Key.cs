using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(KeySave))]
public class Key : Interactible
{

    [SerializeField] GameObject screenKey;
    [SerializeField] GameObject key;
    [SerializeField] public AudioClip drag;
    KeySave save;


    private void Awake()
    {
        save = GetComponent<KeySave>();
    }
    private void Start()
    {
        if (save.isExist)
        {
            screenKey.SetActive(true);
            Collider collider = GetComponent<Collider>();
            collider.enabled = false;
         
            ClearHint();
            Destroy(key, 0.5f);
        }
    }
    public override void DoActivate()
    {
        save.isExist = !save.isExist;
        if (save.isExist)
        {
            screenKey.SetActive(true);
            Collider collider = GetComponent<Collider>();
            collider.enabled = false;
            GetComponent<AudioSource>().PlayOneShot(drag);
            ClearHint();
            Destroy(key, 0.5f);
        }
    
    }


}
