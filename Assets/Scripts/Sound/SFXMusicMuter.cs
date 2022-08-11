using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXMusicMuter : MonoBehaviour
{
    FMOD.Studio.EventInstance muteMusicEvInst;
    string muteMusicPath = "snapshot:/MuteMusic";
    static bool musicMuted = false;
    static bool sfxMuted = false;
    [SerializeField] private GameObject MusicOn;
    [SerializeField] private GameObject MusicOff;
    [SerializeField] private GameObject SFXOn;
    [SerializeField] private GameObject SFXOff;

    FMOD.Studio.EventInstance muteSFXEvInst;
    string muteSFXPath = "snapshot:/MuteSFX";

    FMOD.Studio.PLAYBACK_STATE pbState;

    private void Start()
    {
        muteMusicEvInst = FMODUnity.RuntimeManager.CreateInstance(muteMusicPath);
        Debug.Log("Checking if music is on.");
        if (musicMuted)
        {
            MusicOn.SetActive(false);
            MusicOff.SetActive(true);
            ToggleAudioOff(true);
            Debug.Log("Music is off.");
        }
        else
        {
            MusicOn.SetActive(true);
            MusicOff.SetActive(false);
            ToggleAudioOn(true);
            Debug.Log("Music is on");
        }
        muteSFXEvInst = FMODUnity.RuntimeManager.CreateInstance(muteSFXPath);
        Debug.Log("Checking if SFX are on.");
        if (sfxMuted)
        {
            SFXOn.SetActive(false);
            SFXOff.SetActive(true);
            ToggleAudioOff(false);
            Debug.Log("SFX are not on.");
        }
        else
        {
            SFXOn.SetActive(true);
            SFXOff.SetActive(false);
            ToggleAudioOn(false);
            Debug.Log("SFX are on");
        }
    }
    public void SwitchAudioMusic()
    {
        if (musicMuted)
        {
            MusicOn.SetActive(true);
            MusicOff.SetActive(false);
            ToggleAudioOn(true);
            Debug.Log("Click - Music On");
            musicMuted = false;
        }
        else
        {
            MusicOn.SetActive(false);
            MusicOff.SetActive(true);
            ToggleAudioOff(true);
            Debug.Log("Click - Music Off");
            musicMuted = true;
        }
    }
    public void SwitchAudioSFX()
    {
        if (sfxMuted)
        {
            SFXOn.SetActive(true);
            SFXOff.SetActive(false);
            ToggleAudioOn(false);
            Debug.Log("Click - SFX On");
            sfxMuted = false;
        }
        else
        {
            SFXOn.SetActive(false);
            SFXOff.SetActive(true);
            ToggleAudioOff(false);
            Debug.Log("Click - SFX Off");
            sfxMuted = true;
        }
    }
    public void ToggleAudioOff(bool musicCheckBox)
    {
        if (musicCheckBox) muteMusicEvInst.start();
        else muteSFXEvInst.start();
    }
    public void ToggleAudioOn(bool musicCheckBox)
    {
        if (musicCheckBox) muteMusicEvInst.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        else muteSFXEvInst.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
    private void OnDestroy()
    {
        muteMusicEvInst.getPlaybackState(out pbState);
        //Check if Fmod event MuteMusic is playing, and set static bool to right value for next scene
        if (pbState == FMOD.Studio.PLAYBACK_STATE.PLAYING) musicMuted = true;
        else musicMuted = false;
        muteSFXEvInst.getPlaybackState(out pbState);
        if (pbState == FMOD.Studio.PLAYBACK_STATE.PLAYING) sfxMuted = true;
        else sfxMuted = false;
        ToggleAudioOn(true);
        ToggleAudioOff(false);
        muteMusicEvInst.release();
        muteSFXEvInst.release();
    }
}