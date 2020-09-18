using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : Interactible, IDestructible
{
    [SerializeField] Animator animator;
    bool isOpen = false;
    [SerializeField] private AudioClip destroyWindow;
    [SerializeField] float  maxValue = 1;
    [SerializeField] float  minValue= 0.5f;
    [SerializeField] AudioSource sound;

    public void Start()
    {
       
          sound.volume = 0.5f;
      
    }
    public override void DoActivate()
    {
      
        if (Input.GetKeyDown(KeyCode.F))
        {
            OpenClose();
        }
    }

    public void OpenClose()
    {
        isOpen = !isOpen;
        if (isOpen)
        {
            sound.volume = maxValue;
        }
        else
        {
            sound.volume = minValue;
        }
        animator.SetBool("isOpen", isOpen);
    }
   
    public void DestroyObjects()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<AudioSource>().PlayOneShot(destroyWindow);
            BreakableWindow window = GetComponent<BreakableWindow>();
            window.breakWindow();
            Destroy(gameObject, 1f);
            Collider collider = GetComponent<Collider>();
            collider.enabled = false;
            ClearHint();
            sound.volume = maxValue;
        }
    }
}
