using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(WindowSave))]
public class Window : Interactible, IDestructible
{
    [SerializeField] Animator animator;
    [SerializeField] private AudioClip destroyWindow;
    [SerializeField] float maxValue = 1;
    [SerializeField] float minValue = 0.5f;
    [SerializeField] AudioSource sound;

    [SerializeField] WindowSave save;


    private void Awake()
    {
        save = GetComponent<WindowSave>();
      
    }
    public void Start()
    {
        sound.volume = minValue;
        if (save.isOpen)
        {
            sound.volume = maxValue;
        }
        else
        {
            sound.volume = minValue;
        }
        animator.SetBool("isOpen", save.isOpen);
    }
    public override void DoActivate()
    {
        OpenClose();
    }

    public void OpenClose()
    {
        save.isOpen = !save.isOpen;
        if (save.isOpen)
        {
            sound.volume = maxValue;
        }
        else
        {
            sound.volume = minValue;
        }
        animator.SetBool("isOpen", save.isOpen);
    }

    public void DestroyObjects()
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
