using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(SafeSave))]
public class Safe : Interactible
{
    [SerializeField] GameObject showSafe;
    [SerializeField] Animator animator;
    [SerializeField] UiDoTween uiDoTween;
    [SerializeField] AudioClip openSafe, closeSafe;
    SafeSave save;

    private void Awake()
    {
        save = GetComponent<SafeSave>();

    }
    public override void DoActivate()
    {
        showSafe.gameObject.SetActive(true);
        uiDoTween.Show();
    }
    private void Start()
    {
        if (save.isOpen)
        {
            Collider collider = GetComponent<Collider>();
            collider.enabled = false;
            ClearHint();
            animator.SetTrigger("Open");
            GetComponent<AudioSource>().PlayOneShot(openSafe);
        }
        
    }
    public void Open()
    {
        save.isOpen = !save.isOpen;
        if (save.isOpen)
        {
            Collider collider = GetComponent<Collider>();
            collider.enabled = false;
            ClearHint();
            animator.SetTrigger("Open");
            GetComponent<AudioSource>().PlayOneShot(openSafe);
        }
    }

    public void Close()
    {
        if (!save.isOpen) { 
            GetComponent<AudioSource>().PlayOneShot(closeSafe);
        }
    }

}
