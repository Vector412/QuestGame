using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactible
{
    public AudioClip openDoor, closeDoor;
    [SerializeField] Animator animDoor;
    [SerializeField] GameObject keyScreen;

    public override void DoActivate()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("YEah");
            if (keyScreen.activeInHierarchy == true)
            {
                animDoor = GetComponent<Animator>();
                GetComponent<AudioSource>().PlayOneShot(openDoor);
                animDoor.SetBool("isOpen", true);
                gameObject.GetComponent<BoxCollider>().enabled = false;
                keyScreen.SetActive(false);
            }
            else if (keyScreen.activeInHierarchy == false)
            {
                GetComponent<AudioSource>().PlayOneShot(closeDoor);
            }
        }
    }
}
