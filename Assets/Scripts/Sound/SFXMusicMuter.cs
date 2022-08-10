using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXMusicMuter : MonoBehaviour
{
    FMOD.Studio.EventInstance muteMusicEvInst;
    string muteMusicPath = "snapshot:/MuteMusic";
    static bool musicMuted = false;
    [SerializeField] private GameObject On;
    [SerializeField] private GameObject Off;

    FMOD.Studio.EventInstance muteSFXEvInst;
    string muteSFXPath = "snapshot:/MuteSFX";

    FMOD.Studio.PLAYBACK_STATE pbState;

    private void Start()
    {
        muteMusicEvInst = FMODUnity.RuntimeManager.CreateInstance(muteMusicPath);
        Debug.Log("Checking if music is on.");
        if (musicMuted)
        {
            On.SetActive(false);
            Off.SetActive(true);
            ToggleMusicOff();
            Debug.Log("Music is off.");
        }
        else
        {
            On.SetActive(true);
            Off.SetActive(false);
            ToggleMusicOn();
            Debug.Log("Music is on");
        }
    }

    public void SwitchAudio()
    {
        if (musicMuted)
        {
            On.SetActive(true);
            Off.SetActive(false);
            ToggleMusicOn();
            Debug.Log("Click - Music On");
            musicMuted = false;
        }
        else
        {
            On.SetActive(false);
            Off.SetActive(true);
            ToggleMusicOff();
            Debug.Log("Click - Music Off");
            musicMuted = true;
        }
    }
    public void ToggleMusicOff()
    {
        muteMusicEvInst.start();
    }
    public void ToggleMusicOn()
    {
        muteMusicEvInst.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
    private void OnDestroy()
    {
        muteMusicEvInst.getPlaybackState(out pbState);
        //Check if Fmod event MuteMusic is playing, and set static bool to right value for next scene
        if (pbState == FMOD.Studio.PLAYBACK_STATE.PLAYING) musicMuted = true;
        else musicMuted = false;
        ToggleMusicOn();
        muteMusicEvInst.release();
    }

}