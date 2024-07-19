using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 0.025f; 
    public Vector3 offset;

    private void LateUpdate()
    {
        // 현재 카메라 위치와 목표 위치 사이를 보간하여 새로운 위치 계산
        transform.position = Vector3.Lerp(transform.position, player.position + offset, smoothSpeed);
    }
}
