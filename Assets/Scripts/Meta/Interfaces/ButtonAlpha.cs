using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAlpha : MonoBehaviour
{
    [SerializeField] private CanvasGroup close;
    [SerializeField] private CanvasGroup open;
    
    public void Press()
    {
        close.alpha = 0;
        close.interactable = false;
        close.blocksRaycasts = false;
        
        open.alpha = 1;
        open.interactable = true;
        open.blocksRaycasts = true;
    }
}
