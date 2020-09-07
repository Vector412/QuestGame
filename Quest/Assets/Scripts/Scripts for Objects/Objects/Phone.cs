using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Phone : Interactible
{
    [SerializeField] GameObject phoneIcon;
    [SerializeField] GameObject lockIcon;
    [SerializeField] GameObject[] lockIcons;

    [SerializeField] Text clock;
    [SerializeField] bool isActivePhone;
    [SerializeField] UiDoTween uiDoTween;
    private bool phoneIsInterective;


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
            phoneIsInterective = true;
            uiDoTween.Show();
        }

    }

    public void Update()
    {
        Clock();
        if (Input.GetKeyDown(KeyCode.Space) && phoneIsInterective)
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
        for(int i = 0; i < lockIcons.Length; i++)
        {
            lockIcons[i].SetActive(false);
        }
        isActivePhone = true;
    }

    public void Clock()
    {
        clock.text = DayNight.Instance.Hours.ToString() + ":" + DayNight.Instance.Minutes.ToString();
    }

   



}
