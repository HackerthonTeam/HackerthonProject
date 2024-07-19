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
        angleStep = 180f / numberOfRays; // ����ĳ��Ʈ ���� ���� ���
    }

    void Update()
    {
        attack();  // ���� ������ ����
        castRays();// ����ĳ��Ʈ�� �߻�
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
            // ���콺 ��ġ�� �÷��̾� ��ġ ���� ���͸� ���
            Vector2 dis = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // �÷��̾��� ������ ���콺 ��ġ�� �������� ȸ��
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(dis.y, dis.x) * Mathf.Rad2Deg);
            
        }
    }

    private void castRays()
    {
        if (Input.GetMouseButtonDown(0) && AttCool)
        {
            for (int i = 0; i < numberOfRays; i++)
            {
                // �� ����ĳ��Ʈ�� ������ ���
                float angle = -90 + (i * angleStep);

                // �÷��̾��� ���� ȸ�� ������ �������� ������ �����Ͽ� ����ĳ��Ʈ ���� ���
                Vector3 direction = Quaternion.Euler(0, 0, angle) * -transform.right; // ������ ������ ���� `-transform.right` ���

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
