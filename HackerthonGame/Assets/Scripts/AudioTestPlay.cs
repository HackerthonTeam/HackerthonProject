using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTestPlay : MonoBehaviour
{
    public GameObject sound;
    void Start(){
        SoundManager.Instance.SoundPlay(sound,"1",100,false);
        SoundManager.Instance.SoundPlay(sound,"2",100,false);
    }
}
