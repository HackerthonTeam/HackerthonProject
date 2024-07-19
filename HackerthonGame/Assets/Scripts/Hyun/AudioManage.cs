using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class AudioManage : MonoBehaviour
{
    //public AudioMixer audioMixer;  // ����� �ͼ��� ������ ����

    public void SetVolume(float volume)
    {
        //audioMixer.SetFloat("MasterVol", Mathf.Log10(volume) * 20);
        SoundManager.Instance.masterVol = volume;
    }
}
