using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXMusicMuter : MonoBehaviour
{
    FMOD.Studio.EventInstance muteMusicEvInst;
    string muteMusicPath = "snapshot:/MuteMusic";
    bool musicIsMuted = false;

    FMOD.Studio.EventInstance muteSFXEvInst;
    string muteSFXPath = "snapshot:/MuteSFX";
    bool SFXAreMuted = false;

    public void ToggleMusic(bool setToMute)
    {
        if (setToMute)
        {
            if (musicIsMuted)
            {
                return;
            }
            else
            {
                musicIsMuted = true;
                muteMusicEvInst = FMODUnity.RuntimeManager.CreateInstance(muteMusicPath);
                muteMusicEvInst.start();
            }
        }
        else
        {
            if (!musicIsMuted)
            {
                return;
            }
            else
            {
                musicIsMuted = false;
                muteMusicEvInst = FMODUnity.RuntimeManager.CreateInstance(muteMusicPath);
                muteMusicEvInst.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                muteMusicEvInst.release();
            }
        }
    }
    public void ToggleSFX(bool setToMute)
    {
        if (setToMute)
        {
            if (SFXAreMuted)
            {
                return;
            }
            else
            {
                SFXAreMuted = true;
                muteSFXEvInst = FMODUnity.RuntimeManager.CreateInstance(muteMusicPath);
                muteSFXEvInst.start();
            }
        }
        else
        {
            if (!SFXAreMuted)
            {
                return;
            }
            else
            {
                SFXAreMuted = false;
                muteSFXEvInst = FMODUnity.RuntimeManager.CreateInstance(muteMusicPath);
                muteSFXEvInst.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            }
        }
    }
}
