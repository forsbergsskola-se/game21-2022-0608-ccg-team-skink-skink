using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXMusicMuter : MonoBehaviour
{
    
    [SerializeField] private GameObject MusicOn;
    [SerializeField] private GameObject MusicOff;
    [SerializeField] private GameObject SFXOn;
    [SerializeField] private GameObject SFXOff;



    FMOD.Studio.PLAYBACK_STATE pbState;

    private void Start()
    {
        

        // Debug.Log("Checking if music is on.");
        if (PlayOneShot.musicMuted)
        {
            MusicOn.SetActive(false);
            MusicOff.SetActive(true);
            PlayOneShot.ToggleAudioOff(true);
            // Debug.Log("Music is off.");
        }
        else
        {
            MusicOn.SetActive(true);
            MusicOff.SetActive(false);
            PlayOneShot.ToggleAudioOn(true);
            // Debug.Log("Music is on");
        }

        // Debug.Log("Checking if SFX are on.");
        if (PlayOneShot.sfxMuted)
        {
            SFXOn.SetActive(false);
            SFXOff.SetActive(true);
            PlayOneShot.ToggleAudioOff(false);
            // Debug.Log("SFX are not on.");
        }
        else
        {
            SFXOn.SetActive(true);
            SFXOff.SetActive(false);
            PlayOneShot.ToggleAudioOn(false);
            // Debug.Log("SFX are on");
        }
    }
    public void SwitchAudioMusic()
    {
        if (PlayOneShot.musicMuted)
        {
            MusicOn.SetActive(true);
            MusicOff.SetActive(false);
            PlayOneShot.ToggleAudioOn(true);
            // Debug.Log("Click - Music On");
            PlayOneShot.musicMuted = false;
        }
        else
        {
            MusicOn.SetActive(false);
            MusicOff.SetActive(true);
            PlayOneShot.ToggleAudioOff(true);
            // Debug.Log("Click - Music Off");
            PlayOneShot.musicMuted = true;
        }
    }
    public void SwitchAudioSFX()
    {
        if (PlayOneShot.sfxMuted)
        {
            SFXOn.SetActive(true);
            SFXOff.SetActive(false);
            PlayOneShot.ToggleAudioOn(false);
            // Debug.Log("Click - SFX On");
            PlayOneShot.sfxMuted = false;
        }
        else
        {
            SFXOn.SetActive(false);
            SFXOff.SetActive(true);
            PlayOneShot.ToggleAudioOff(false);
            // Debug.Log("Click - SFX Off");
            PlayOneShot.sfxMuted = true;
        }
    }

    /*private void OnDestroy()
    {
        muteMusicEvInst.getPlaybackState(out pbState);
        //Check if Fmod event MuteMusic is playing, and set static bool to right value for next scene
        if (pbState == FMOD.Studio.PLAYBACK_STATE.PLAYING) musicMuted = true;
        else musicMuted = false;
        muteSFXEvInst.getPlaybackState(out pbState);
        if (pbState == FMOD.Studio.PLAYBACK_STATE.PLAYING) sfxMuted = true;
        else sfxMuted = false;
        //ToggleAudioOn(true);
        //ToggleAudioOff(false);
        muteMusicEvInst.release();
        muteSFXEvInst.release();
    }
    */
}