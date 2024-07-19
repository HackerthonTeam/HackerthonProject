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
        // ���� ī�޶� ��ġ�� ��ǥ ��ġ ���̸� �����Ͽ� ���ο� ��ġ ���
        transform.position = Vector3.Lerp(transform.position, player.position + offset, smoothSpeed);
    }
}
