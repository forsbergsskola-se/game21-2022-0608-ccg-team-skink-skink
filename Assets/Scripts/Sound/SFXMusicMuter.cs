using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXMusicMuter : MonoBehaviour
{
    FMOD.Studio.EventInstance muteMusicEvInst;
    string muteMusicPath = "snapshot:/MuteMusic";
    static bool musicMuted;

    FMOD.Studio.EventInstance muteSFXEvInst;
    string muteSFXPath = "snapshot:/MuteSFX";
    
    FMOD.Studio.PLAYBACK_STATE pbState;

    private void Start()
    {
        muteMusicEvInst = FMODUnity.RuntimeManager.CreateInstance(muteMusicPath);
        if (musicMuted)
        {
            muteMusicEvInst.start();
        }
    }
    public void ToggleMusicMuted()
    {
       muteMusicEvInst.getPlaybackState(out pbState);
        if (pbState == FMOD.Studio.PLAYBACK_STATE.PLAYING) return;
        else
        {
            musicMuted = true;
            muteMusicEvInst.start();
        }
    }
    public void ToggleMusicOn()
    {
        muteMusicEvInst.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        musicMuted = false;
    }
    private void OnDestroy()
    {
        ToggleMusicOn();
        muteMusicEvInst.release();
    }
}

    