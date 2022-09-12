using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuAudioManager : MonoBehaviour
{
    [Header("Options")]
    public Slider masterVolume;
    public Slider volumeFX;
    public Toggle mute;
    public AudioMixer menuMixer;
    public AudioSource fxSource;
    public AudioClip clickSound;
    private float lastVol;
    


    private void Awake(){
        masterVolume.onValueChanged.AddListener(ChangeVolumeMaster);
        volumeFX.onValueChanged.AddListener(ChangeVolumeFX);
    }


    public void ChangeVolumeMaster(float vol){
        menuMixer.SetFloat("masterVolume", vol);
    }

    public void ChangeVolumeFX(float vol){
        menuMixer.SetFloat("volumeFX", vol);
    }

    public void PlaySoundButton(){
        fxSource.PlayOneShot(clickSound);
    }

    public void Mute(){
        if (mute.isOn){
            menuMixer.GetFloat("masterVolume", out lastVol);
            menuMixer.SetFloat("masterVolume", -80);
        }else{
            menuMixer.SetFloat("masterVolume", lastVol);
        }
    }
}