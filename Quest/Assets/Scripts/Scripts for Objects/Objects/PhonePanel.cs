using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhonePanel : MonoBehaviour
{
    [SerializeField] GameObject[] hideIcons;
    public void HidePhone()
    {
        for (int i = 0; i < hideIcons.Length; i++)
        {
            hideIcons[i].SetActive(false);
        }
    }
}
