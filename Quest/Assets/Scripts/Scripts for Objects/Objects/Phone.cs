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



    public void Start()
    {
        lockIcon.gameObject.SetActive(isActivePhone);
        isActivePhone = !isActivePhone;

    }


    public override void DoActivate()
    {
        phoneIcon.gameObject.SetActive(true);
        phoneIsInterective = true;
        uiDoTween.Show();
        ClearHint();
    }

    public void Update()
    {
        Clock();
        {
            if (Input.GetKeyDown(KeyCode.F1) && phoneIsInterective)
            {
                LockUnlock();
            }
        }

    }

    public void LockUnlock()
    {
        lockIcon.gameObject.SetActive(isActivePhone);
        txtFile.gameObject.SetActive(isActivePhone);
        isActivePhone = !isActivePhone;
    }
    public void Lock()
    {
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
