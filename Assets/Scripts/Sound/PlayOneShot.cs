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
        invalidInputInst = FMODUnity.RuntimeManager.CreateInstance(cardActivatedRef);
        apCapInst = FMODUnity.RuntimeManager.CreateInstance(apCapRef);

    }

    void Update()
    {
        
    }
    void PlayCardAudio()
    {
        playCardInst.start();
        playCardInst.release();
    }
    void ActivateCardAudio()
    {
        cardActivatedInst.start();
        cardActivatedInst.release();
    }
    void IvalidInputAudio()
    {
        invalidInputInst.start();
        cardActivatedInst.release();
    }
    void ApCapAudio()
    {
        apCapInst.start();
        apCapInst.release();

    }
}
