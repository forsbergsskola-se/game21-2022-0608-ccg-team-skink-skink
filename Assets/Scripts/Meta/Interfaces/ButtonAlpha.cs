using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAlpha : MonoBehaviour
{
    [SerializeField] private CanvasGroup close;
    [SerializeField] private CanvasGroup open;

    private string soundEventPath = "event:/ButtonPress";
    
    public void Press()
    {
        open.alpha = 1;
        close.interactable = false;
        close.blocksRaycasts = false;
        
        close.alpha = 0;
        open.interactable = true;
        open.blocksRaycasts = true;
        PlayButtonSound();
    }
    void PlayButtonSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot(soundEventPath);
    }
    
    
}
