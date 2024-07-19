using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
    public float arrange;
    public int amount;
    public float SpawnCooltime;
    public BaseEntity entity;

    float curTime;
    Player player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    private void Update()
    {
        curTime += Time.deltaTime;
        if(curTime > SpawnCooltime && (transform.position - player.transform.position).magnitude > 15)
        {
            curTime = 0;
            Spawn();
        }
    }
    void Spawn()
    {
        for(int i = 0; i < amount; i++)
        {
            Vector2 randPos = GenerateRandomPointInCircle() + (Vector2)transform.position;
            PoolManager.Instance.GetPool(entity.gameObject, randPos, Quaternion.identity);
        }
    }

    Vector2 GenerateRandomPointInCircle()
    {
        float t = 2 * Mathf.PI * Random.value; // 무작위 각도
        float u = Random.value + Random.value;
        float r = (u > 1) ? 2 - u : u; // 원의 반지름 내에서 무작위 거리
        return arrange * r * new Vector2(Mathf.Cos(t), Mathf.Sin(t)); // 극좌표를 직교좌표로 변환
    }
}
