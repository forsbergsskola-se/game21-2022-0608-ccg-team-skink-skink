using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAlpha : MonoBehaviour
{
    [SerializeField] private CanvasGroup close;
    [SerializeField] private CanvasGroup open;
    [SerializeField] private Animator anim;
    private string soundEventPath = "event:/ButtonPress";

    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    public void Press()
    {
        anim.SetTrigger("Close");
        close.interactable = false;
        close.blocksRaycasts = false;
        
        open.alpha = 1;
        
        PlayButtonSound();
    }
    void PlayButtonSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot(soundEventPath);
    }

    public void HideScreen()
    {
        close.alpha = 0;
        open.interactable = true;
        open.blocksRaycasts = true;
    }
}
