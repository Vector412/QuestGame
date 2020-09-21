using UnityEngine;
using UnityEngine.UI;

public class Phone : Interactible
{
    [SerializeField] GameObject phoneIcon;
    [SerializeField] GameObject lockIcon;

    [SerializeField] GameObject txtFile;
   
    [SerializeField] GameObject[] lockIcons;

    [SerializeField] Text clock;
    [SerializeField] bool isActivePhone;
    [SerializeField] UiDoTween uiDoTween;
    private bool phoneIsInterective;
    private bool textFileActive;



    public void Start()
    {
        lockIcon.gameObject.SetActive(isActivePhone);
        isActivePhone = !isActivePhone;
    }


    public override void DoActivate()
    {
       
        if (Input.GetKeyDown(KeyCode.F)) // input manager
        {
            phoneIcon.gameObject.SetActive(true);
            phoneIsInterective = true;
            uiDoTween.Show();
            ClearHint();
          
        }

    }

    public void Update()
    {
        Clock();
        {
            if (Input.GetKeyDown(KeyCode.F1) && phoneIsInterective)
            {
                if (!isActivePhone) // заменить 
                {
                    Lock();

                }
                else
                {
                    Unlock();
                }
            }
        }

    }

    public void Unlock()
    {
        lockIcon.gameObject.SetActive(true);
        txtFile.gameObject.SetActive(true);
        isActivePhone = false;

    }
    public void Lock()
    {
        //разить канвас
        for (int i = 0; i < lockIcons.Length; i++)
        {
            lockIcons[i].SetActive(false);
            
        }
        isActivePhone = true;
    }

    public void Clock()
    {
        clock.text = $"{DayNight.Instance.Hours}:{DayNight.Instance.Minutes}";
    }





}
