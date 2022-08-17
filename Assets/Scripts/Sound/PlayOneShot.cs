using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayOneShot
{
    //public FMODUnity.EventReference playCardRef;
    static string playCardPath = "event:/Cards/PlayCard";
    static FMOD.Studio.EventInstance playCardInst = FMODUnity.RuntimeManager.CreateInstance(playCardPath);

    //public FMODUnity.EventReference cardActivatedRef;
    static string cardActivatedPath = "event:/Cards/CardActivated";
    static FMOD.Studio.EventInstance cardActivatedInst = FMODUnity.RuntimeManager.CreateInstance(cardActivatedPath);

    //public FMODUnity.EventReference invalidInputRef;
    static string invalidInputPath = "event:/InvalidInput";
    static FMOD.Studio.EventInstance invalidInputInst = FMODUnity.RuntimeManager.CreateInstance(invalidInputPath);

    //public FMODUnity.EventReference apCapRef;
    static string apCapPath = "event:/APcap";
    static FMOD.Studio.EventInstance apCapInst = FMODUnity.RuntimeManager.CreateInstance(apCapPath);

    static public void PlayCardAudio()
    {
        playCardInst.start();
        Debug.Log("Play card");
    }
    static public void ActivateCardAudio()
    {
        cardActivatedInst.start();
    }
    static public void InvalidInputAudio()
    {
        invalidInputInst.start();
        Debug.Log("Trying to play card");
    }
    static public void ApCapAudio()
    {
        apCapInst.start();
        Debug.Log("cap");
    }
}
