using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSounds : MonoBehaviour
{
    public FMODUnity.EventReference dmgTakenPlaceEventHere;
    FMOD.Studio.EventInstance dmgTakenInstance;
    public FMODUnity.EventReference deathPlaceEventHere;
    FMOD.Studio.EventInstance deathInstance;
    public FMODUnity.EventReference attackPlaceEventHere;
    FMOD.Studio.EventInstance attackInstance;

    void Start()
    {
        dmgTakenInstance = FMODUnity.RuntimeManager.CreateInstance(dmgTakenPlaceEventHere);
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(dmgTakenInstance, GetComponent<Transform>(), GetComponent<Rigidbody>());
        attackInstance = FMODUnity.RuntimeManager.CreateInstance(attackPlaceEventHere);
    }
    void PlayDmgTakenSound()
    {
        if (PlaybackState(dmgTakenInstance) == FMOD.Studio.PLAYBACK_STATE.PLAYING) return;
        else
        {
            dmgTakenInstance.start();
        }
    }
    void PlayDeathSound()
    {
        deathInstance = FMODUnity.RuntimeManager.CreateInstance(deathPlaceEventHere);
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(deathInstance, GetComponent<Transform>(), GetComponent<Rigidbody>());
        deathInstance.start();
        ReleaseAllInstances();
        dmgTakenInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        dmgTakenInstance.release();
    }
    FMOD.Studio.PLAYBACK_STATE PlaybackState(FMOD.Studio.EventInstance instance)
    {
        FMOD.Studio.PLAYBACK_STATE pS;
        instance.getPlaybackState(out pS);
        return pS;
    }
    void PlayAttackSound()
    {
        attackInstance.start();
    }
    void ReleaseAllInstances()
    {
        deathInstance.release();
        dmgTakenInstance.release();
        attackInstance.release();
    }
}
