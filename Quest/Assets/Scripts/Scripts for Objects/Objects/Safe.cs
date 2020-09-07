using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Safe : Interactible 
{
    [SerializeField] GameObject showSafe;
    [SerializeField] Animator animator;
     [SerializeField] public AudioClip openSafe;



    public override void DoActivate()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            showSafe.gameObject.SetActive(true);
        }
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
        Debug.Log("Close");
    }
    
    

  





}
