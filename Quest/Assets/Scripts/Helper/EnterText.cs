using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterText : MonoBehaviour
{
    [SerializeField] private string editText;
    [SerializeField] private Text inputField;
    [SerializeField] private Text textMessages;

    public void InputText()
    {
        editText = inputField.text;
        textMessages.text += " " + editText.ToString();
        Debug.Log(11);
    }
    
}
