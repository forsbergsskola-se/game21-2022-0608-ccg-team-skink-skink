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
    }
    static public void ActivateCardAudio()
    {
        cardActivatedInst.start();
    }
    static public void InvalidInputAudio()
    {
        invalidInputInst.start();
    }
    static public void ApCapAudio()
    {
        apCapInst.start();
    }
}
