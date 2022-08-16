using UnityEngine;

public class UnitSounds : MonoBehaviour
{
    string dmgTaken = "event:/Units/UnitTakesDmg";
    string unitDeath = "event:/Units/UnitDeath";
    //string unitAttack = "event:/Units/UnitAttack";
    //public FMODUnity.EventReference dmgTakenPlaceEventHere;
    FMOD.Studio.EventInstance dmgTakenInstance;
    //public FMODUnity.EventReference deathPlaceEventHere;
    FMOD.Studio.EventInstance deathInstance;
    //public FMODUnity.EventReference attackPlaceEventHere;
    FMOD.Studio.EventInstance attackInstance;
    string audienceReactsPath = "event:/Audience/AudienceReacts";
    FMOD.Studio.EventInstance audienceReactsInstance;


    void Start()
    {
        dmgTakenInstance = FMODUnity.RuntimeManager.CreateInstance(dmgTaken);
        //attackInstance = FMODUnity.RuntimeManager.CreateInstance(unitAttack);
        deathInstance = FMODUnity.RuntimeManager.CreateInstance(unitDeath);
        audienceReactsInstance = FMODUnity.RuntimeManager.CreateInstance(audienceReactsPath);
    }
    public void PlayDmgTakenSound()
    {
        if (PlaybackState(dmgTakenInstance) == FMOD.Studio.PLAYBACK_STATE.PLAYING) return;
        else
        {
            FMODUnity.RuntimeManager.AttachInstanceToGameObject(dmgTakenInstance, GetComponent<Transform>(), GetComponent<Rigidbody>());
            dmgTakenInstance.start();
        }
    }
    public void PlayDeathSound()
    {
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("DramaticCue", 1);
        Debug.Log("Playing dramatic cue");
        audienceReactsInstance.start();
        //FMODUnity.RuntimeManager.AttachInstanceToGameObject(deathInstance, GetComponent<Transform>(), GetComponent<Rigidbody>());
        deathInstance.start();
        dmgTakenInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
    FMOD.Studio.PLAYBACK_STATE PlaybackState(FMOD.Studio.EventInstance instance)
    {
        FMOD.Studio.PLAYBACK_STATE pS;
        instance.getPlaybackState(out pS);
        return pS;
    }
    public void PlayAttackSound()
    {
        attackInstance.start();
    }
    public void AudienceReacts()
    {
        audienceReactsInstance.start();
    }
    public void ReleaseAllInstances()
    {
        deathInstance.release();
        dmgTakenInstance.release();
        attackInstance.release();
    }
    private void OnDestroy()
    {
        ReleaseAllInstances();
    }
}
