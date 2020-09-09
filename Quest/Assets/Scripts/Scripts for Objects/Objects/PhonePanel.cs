using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhonePanel : MonoBehaviour
{
    [SerializeField] GameObject[] hideIcons;
    [SerializeField] GameObject file;
    [SerializeField] GameObject button;
    private int timeTape;
    public void HidePhone()
    {
        for (int i = 0; i < hideIcons.Length; i++)
        {
            hideIcons[i].SetActive(false);
        }
    }

    public void TapButton()
    {
        timeTape++;
        if (timeTape >= 2)
        {
            file.SetActive(true);
            button.SetActive(false);
            timeTape = 0;
        }
    }
}
