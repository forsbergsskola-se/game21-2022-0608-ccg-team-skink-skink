using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOneShot : MonoBehaviour
{
    public FMODUnity.EventReference playCardRef;
    FMOD.Studio.EventInstance playCardInst;

    public FMODUnity.EventReference cardActivatedRef;
    FMOD.Studio.EventInstance cardActivatedInst;

    public FMODUnity.EventReference invalidInputRef;
    FMOD.Studio.EventInstance invalidInputInst;

    public FMODUnity.EventReference apCapRef;
    FMOD.Studio.EventInstance apCapInst;
    void Start()
    {
        playCardInst = FMODUnity.RuntimeManager.CreateInstance(playCardRef);
        cardActivatedInst = FMODUnity.RuntimeManager.CreateInstance(cardActivatedRef);
        invalidInputInst = FMODUnity.RuntimeManager.CreateInstance(invalidInputRef);
        apCapInst = FMODUnity.RuntimeManager.CreateInstance(apCapRef);
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
