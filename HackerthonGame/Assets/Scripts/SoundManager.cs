using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    [Range(0,1f)]public float masterVol;
    public void SoundPlay(GameObject gameObject,string audioSourceName,float vol,bool isLoop){
        AudioClip audio = Resources.Load("Audio/"+audioSourceName,typeof(AudioClip))as AudioClip;
        gameObject.GetComponent<AudioSource>().clip = audio;
        gameObject.GetComponent<AudioSource>().volume = (vol/100f)*(masterVol);
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
        GameObject.Find("AudioManager").GetComponent<AudioSource>().volume = (vol/100f)*(masterVol);
        GameObject.Find("AudioManager").GetComponent<AudioSource>().loop = true;
        GameObject.Find("AudioManager").GetComponent<AudioSource>().PlayOneShot(Resources.Load("Audio/"+backgroundSource,typeof(AudioClip))as AudioClip);
    }
    public void Awake(){
        DontDestroyOnLoad(this.gameObject);
    }
}
