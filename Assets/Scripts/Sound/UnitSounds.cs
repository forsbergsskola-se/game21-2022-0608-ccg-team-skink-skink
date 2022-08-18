using Gameplay.Unit.Health;
using UnityEngine;

public class UnitSounds : MonoBehaviour
{
    string dmgTaken = "event:/Units/UnitTakesDmg";
    string unitDeath = "event:/Units/UnitDeath";
    //string unitAttack = "event:/Units/UnitAttack";
    //public FMODUnity.EventReference dmgTakenPlaceEventHere;
    //public FMODUnity.EventReference deathPlaceEventHere;
    FMOD.Studio.EventInstance deathInstance;
    //public FMODUnity.EventReference attackPlaceEventHere;
    FMOD.Studio.EventInstance attackInstance;
    string audienceReactsPath = "event:/Audience/AudienceReacts";
    FMOD.Studio.EventInstance audienceReactsInstance;
    FMOD.Studio.EventInstance dmgTakenInstance;


    void Start()
    {
        //attackInstance = FMODUnity.RuntimeManager.CreateInstance(unitAttack);
        deathInstance = FMODUnity.RuntimeManager.CreateInstance(unitDeath);
        GetComponent<HealthComponent>().OnDamageTaken.AddListener(PlayDmgTakenSound);
    }
    public void PlayDmgTakenSound()
    {
        dmgTakenInstance = FMODUnity.RuntimeManager.CreateInstance(dmgTaken);
        dmgTakenInstance.start();
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(dmgTakenInstance, GetComponent<Transform>(), GetComponent<Rigidbody>());
    }
    public void PlayDeathSound()
    {
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("DramaticCue", 1);
        audienceReactsInstance = FMODUnity.RuntimeManager.CreateInstance(audienceReactsPath);
        audienceReactsInstance.start();
        audienceReactsInstance.release();
        deathInstance.start();
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(deathInstance, GetComponent<Transform>(), GetComponent<Rigidbody>());
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
