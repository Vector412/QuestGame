using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactible
{
    [SerializeField] public AudioClip openDoor, closeDoor;
    [SerializeField] Animator animDoor;
    [SerializeField] GameObject keyScreen;
  

    public override void DoActivate()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (keyScreen.activeInHierarchy == true)
            {
                OpenDoor();
                DeactivateDoor();

             
            }
            else if (keyScreen.activeInHierarchy == false)
            {
                CloseDoor();
            }
        }
    }

    public void OpenDoor()
    {
        animDoor = GetComponent<Animator>();
        GetComponent<AudioSource>().PlayOneShot(openDoor);
        animDoor.SetBool("isOpen", true);
    }

    public void DeactivateDoor()
    {
        Collider collider = GetComponent<Collider>();
        collider.enabled = false;
        ClearHint();

    }

    public void CloseDoor()
    {
        GetComponent<AudioSource>().PlayOneShot(closeDoor);
    }
}
