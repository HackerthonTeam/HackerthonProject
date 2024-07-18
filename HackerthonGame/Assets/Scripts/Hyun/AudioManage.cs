using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class AudioManage : MonoBehaviour
{
    public AudioMixer audioMixer;  // 오디오 믹서를 연결할 변수

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("MasterVol", Mathf.Log10(volume) * 20);
    }
}
