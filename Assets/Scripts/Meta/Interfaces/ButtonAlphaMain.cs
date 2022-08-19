using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAlphaMain : MonoBehaviour
{
    [SerializeField] private bool mainmenu;
    [SerializeField] private CanvasGroup close;
    [SerializeField] private CanvasGroup open;
    [SerializeField] private Animator anim;
    private string soundEventPath = "event:/ButtonPress";
    

    public void Press()
    {
        open.alpha = 1;
        if(mainmenu)
            anim.SetTrigger("Close");
        else
            anim.SetTrigger("Open");
        close.interactable = false;
        close.blocksRaycasts = false;
        
        PlayButtonSound();
    }
    void PlayButtonSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot(soundEventPath);
    }

    public void HideMainScreen()
    {
        close.alpha = 0;
        open.interactable = true;
        open.blocksRaycasts = true;
    }

    public void HideHubScreen()
    {
        open.alpha = 0;
        close.interactable = true;
        close.blocksRaycasts = true;
    }
    
}
