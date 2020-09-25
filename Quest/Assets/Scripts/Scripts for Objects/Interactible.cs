using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Interactible : MonoBehaviour
{
    [SerializeField] GameObject hint;

    public void ShowHint()
    {
        if(hint)
        hint.gameObject.SetActive(true);
    }

    public void ClearHint()
    {
        if(hint)
        hint.gameObject.SetActive(false);
    }

    public virtual void DoActivate()
    {
        Debug.Log("DoActivate");
        
    }


}
