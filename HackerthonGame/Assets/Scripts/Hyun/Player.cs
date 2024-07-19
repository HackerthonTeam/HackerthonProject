using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<bool> Status = new List<bool>(); 
    public float radius = 3f;        
    public int numberOfRays = 20;    
    private float angleStep;
    public float time = 3f;
    private bool AttCool = true;
    void Start()
    {
        angleStep = 180f / numberOfRays; // 레이캐스트 간의 각도 계산
    }

    void Update()
    {
        attack();  // 공격 동작을 수행
        castRays();// 레이캐스트를 발사
        time +=  Time.deltaTime;

        if(time >= 3)
        {
            AttCool = true;
            time = 0;
        }
    }
    

    private void attack()
    {
        if (Input.GetMouseButtonDown(0) )
        {
            // 마우스 위치와 플레이어 위치 간의 벡터를 계산
            Vector2 dis = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // 플레이어의 방향을 마우스 위치를 기준으로 회전
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(dis.y, dis.x) * Mathf.Rad2Deg);
            
        }
    }

    private void castRays()
    {
        if (Input.GetMouseButtonDown(0) && AttCool)
        {
            for (int i = 0; i < numberOfRays; i++)
            {
                // 각 레이캐스트의 각도를 계산
                float angle = -90 + (i * angleStep);

                // 플레이어의 현재 회전 방향을 기준으로 각도를 적용하여 레이캐스트 방향 계산
                Vector3 direction = Quaternion.Euler(0, 0, angle) * -transform.right; // 방향을 뒤집기 위해 `-transform.right` 사용

                Ray ray = new Ray(transform.position, direction);
                RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, radius);


                if (hit.collider != null)
                {
                    Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);

                }
                else
                {
                    Debug.DrawRay(ray.origin, ray.direction * radius, Color.green);
                }
            }
            AttCool = false;
        }
    }
}
