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
    [SerializeField] float duration;

    RectTransform rectTransform;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
      
    }
    public void CodePanel()
    {
        Safe safe = FindObjectOfType<Safe>();

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
            currentCode = "";
        }
        currentCode += number;
        Debug.Log(number);
        codeText.text = currentCode;
    }

    public void Clear()
    {
        for (int i = 0; i < currentCode.Length; i++)
        {
            currentCode = "";
            codeText.text = currentCode;

        }
    }

   
   

}
