using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Safe : Interactible
{
    [SerializeField] GameObject showSafe;
    [SerializeField] Animator animator;
    [SerializeField] UiDoTween uiDoTween;
    [SerializeField] AudioClip openSafe, closeSafe;


 
    public override void DoActivate()
    {
        showSafe.gameObject.SetActive(true);
        uiDoTween.Show();
    }

    public void Open()
    {
        Collider collider = GetComponent<Collider>();
        collider.enabled = false;
        ClearHint();
        animator.SetTrigger("Open");
        GetComponent<AudioSource>().PlayOneShot(openSafe);
    }

    public void Close()
    {
        GetComponent<AudioSource>().PlayOneShot(closeSafe);
    }

}
