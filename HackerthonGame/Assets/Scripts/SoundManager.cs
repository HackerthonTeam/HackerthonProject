using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Range(0,100f)]public float masterVol;
    public void SoundPlay(GameObject gameObject,string audioSourceName,float vol,bool isLoop){
        AudioClip audio = Resources.Load("Audio/"+audioSourceName,typeof(AudioClip))as AudioClip;
        gameObject.GetComponent<AudioSource>().volume = (vol/100f)/(masterVol/100f);
        gameObject.GetComponent<AudioSource>().loop = isLoop;
        gameObject.GetComponent<AudioSource>().PlayOneShot(audio);
    }
    public void EffectSoundStop(GameObject gameObject){
        gameObject.GetComponent<AudioSource>().Stop();
    }
    public void EffectSoundPause(GameObject gameObject){
        gameObject.GetComponent<AudioSource>().Pause();
    }
    public void EffectSoundMute(GameObject gameObject){
        gameObject.GetComponent<AudioSource>().mute=true;
    }

    public void BackgroundPlay(string backgroundSource,float vol){
        this.GetComponent<AudioSource>().volume = vol/100f;
        this.GetComponent<AudioSource>().loop = true;
        this.GetComponent<AudioSource>().PlayOneShot(Resources.Load("Audio/"+backgroundSource,typeof(AudioClip))as AudioClip);
    }
}
