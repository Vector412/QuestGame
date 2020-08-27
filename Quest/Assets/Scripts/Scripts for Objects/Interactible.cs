using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Interactible : MonoBehaviour
{
    
    public void ShowHint()
    {
       
    }
    public virtual void DoActivate()
    {
        Debug.Log("DoActivate");
    }


}
