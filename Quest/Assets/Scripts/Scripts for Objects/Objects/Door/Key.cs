using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Interactible
{
    [SerializeField] GameObject screenKey;
    [SerializeField] GameObject key;
    [SerializeField] public AudioClip drag;
    public override void DoActivate()
    {
       
        if (Input.GetKeyDown(KeyCode.F))
        {
            screenKey.SetActive(true);
            Collider collider = GetComponent<Collider>();
            collider.enabled = false;
            GetComponent<AudioSource>().PlayOneShot(drag);
            ClearHint();
            Destroy(key,0.5f);
        }
    }


}
