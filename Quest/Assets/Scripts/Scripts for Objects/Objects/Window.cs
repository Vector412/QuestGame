using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : Interactible, IDestructible
{
    [SerializeField] Animator animator;
    [SerializeField] bool isOpen = false;
    [SerializeField] public AudioClip destroyWindow;

    public override void DoActivate()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!isOpen)
            {
                animator.SetTrigger("Open");
                isOpen = false;
               
            }
            else
            {
                animator.SetTrigger("Close");
                isOpen = true;
            }
        }
    }

    public void DestroyObjects()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<AudioSource>().PlayOneShot(destroyWindow);
            Destroy(gameObject,0.5f);
            Collider collider = GetComponent<Collider>();
            collider.enabled = false;
            ClearHint();
        }
    }
}
