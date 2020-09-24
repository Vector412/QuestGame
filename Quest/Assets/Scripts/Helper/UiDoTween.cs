using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UiDoTween : MonoBehaviour
{
    [Tooltip("Скорость выезда таблицы")] [SerializeField] [Range(0, 1)] float duration;
    [SerializeField] int startPos = 0;
    [SerializeField] int endPos=-250 ;

     

    RectTransform rectTransform;



    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        Hide();
      

    }
  
  
    public void Show()
    {
       gameObject.SetActive(true);
        rectTransform.DOAnchorPosY(startPos, duration);


    }
    public void Hide()
    {
        rectTransform.DOAnchorPosY(endPos, duration).SetRelative(true).OnComplete(() => gameObject.SetActive(false));
    }

   
}
