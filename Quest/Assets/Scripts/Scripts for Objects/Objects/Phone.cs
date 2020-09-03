using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : Interactible
{
    [SerializeField] GameObject phoneIcon;
    [SerializeField] GameObject lockIcon;
    [SerializeField] bool isActivePhone;


    public void Start()
    {
        if (isActivePhone)
        {
            lockIcon.gameObject.SetActive(true);
            isActivePhone = false;

        }
        else
        {
            lockIcon.gameObject.SetActive(false);
            isActivePhone = true;
        }
    }


    public override void DoActivate()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            phoneIcon.gameObject.SetActive(true);
        }

    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (!isActivePhone)
            {
                Lock();
            }
            else
            {
                Unlock();
            }


        }
    }

    public void Unlock()
    {
        lockIcon.gameObject.SetActive(true);
        isActivePhone = false;

    }
    public void Lock()
    {
        lockIcon.gameObject.SetActive(false);
        isActivePhone = true;
    }




}
