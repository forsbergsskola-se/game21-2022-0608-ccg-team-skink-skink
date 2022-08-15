using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOneShot : MonoBehaviour
{
    //public FMODUnity.EventReference playCardRef;
    string playCardPath;
    FMOD.Studio.EventInstance playCardInst;

    //public FMODUnity.EventReference cardActivatedRef;
    string cardActivatedPath;
    FMOD.Studio.EventInstance cardActivatedInst;

    //public FMODUnity.EventReference invalidInputRef;
    string invalidInputPath;
    FMOD.Studio.EventInstance invalidInputInst;

    //public FMODUnity.EventReference apCapRef;
    string apCapPath;
    FMOD.Studio.EventInstance apCapInst;
    void Start()
    {
        playCardInst = FMODUnity.RuntimeManager.CreateInstance(playCardPath);
        cardActivatedInst = FMODUnity.RuntimeManager.CreateInstance(cardActivatedPath);
        invalidInputInst = FMODUnity.RuntimeManager.CreateInstance(invalidInputPath);
        apCapInst = FMODUnity.RuntimeManager.CreateInstance(apCapPath);
    }
    public void PlayCardAudio()
    {
        playCardInst.start();
        playCardInst.release();
    }
    public void ActivateCardAudio()
    {
        cardActivatedInst.start();
        cardActivatedInst.release();
    }
    public void InvalidInputAudio()
    {
        invalidInputInst.start();
        cardActivatedInst.release();
    }
    public void ApCapAudio()
    {
        apCapInst.start();
        apCapInst.release();
    }
}
