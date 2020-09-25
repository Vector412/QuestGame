using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SafePanel : MonoBehaviour
{
    [SerializeField] Text codeText;
    [SerializeField] string currentCode;
    [SerializeField] string code;
    [SerializeField] int lenghtCode;
    Safe safe;

    RectTransform rectTransform;
    private void Awake()
    {
        safe = FindObjectOfType<Safe>();
        rectTransform = GetComponent<RectTransform>();     
    }
    public void CodePanel()
    {
        if (currentCode == code)
        {         
            safe.Open();
        }
        else
        {
            safe.Close();
        }
    }
    public void AddNumber(string number)
    {
        if (currentCode.Length >= lenghtCode)
        {
            currentCode = string.Empty;
        }
        currentCode += number;
        Debug.Log(number);
        codeText.text = currentCode;
    }
    public void Clear()
    {
            currentCode = string.Empty;
            codeText.text = currentCode;
    }
}
