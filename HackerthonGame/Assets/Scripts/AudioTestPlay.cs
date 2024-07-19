using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTestPlay : MonoBehaviour
{    void Start(){
        SoundManager.Instance.BackgroundPlay("1",100);
    }
}
