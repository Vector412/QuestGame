using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EditMessages : MonoBehaviour
{
    [SerializeField] private string editText;
    [SerializeField] private Text inputField;
    [SerializeField] Text textMessages;
  
    private void Start()
    {
            textMessages.text += " " + editText.ToString();
    }

    public void InputText()
    {
        editText = inputField.text;
        textMessages.text += " " + editText.ToString();
    }


    public void Clear()
    {
         textMessages.text =string.Empty; 
    }

}
