using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[Serializable]
public class PlayerData
{
    private float health;
    public float Health { get => health; set { health = Mathf.Clamp(value, 0, 100); } }

    private float moveSpeed;
    public float MoveSpeed {get => moveSpeed; set => moveSpeed = value; }

    private float stemina;
    public float Stemina { get => stemina; set => stemina = value; }

    private float temperature;
    public float Temperature { get => temperature; set => temperature = value; }

    private float temperatureDurability;
    public float TemperatureDurability {get => temperatureDurability; set => temperatureDurability = value; }

    private float hunger;
    public float Hunger { get => hunger; set => hunger = value; }
}

public class Player : MonoBehaviour
{
    PlayerData playerData = new();
    public PlayerData PlayerData => playerData;

    public List<SpecialState> currentStates = new List<SpecialState>(); 
    public List<SpecialState> addedStates = new List<SpecialState>(); 
    public float radius = 3f;        
    public int numberOfRays = 20;    
    private float angleStep;
    private float time = 3f;
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

        ManageState();
    }

    void ManageState()
    {
        foreach(SpecialState state in addedStates)
        {
            currentStates.Add(state);
        }
        addedStates.Clear();

        foreach (SpecialState state in currentStates)
        {
            state.OnUpdated();
            state.duration -= Time.deltaTime;
        }

        foreach (SpecialState state in currentStates)
        {
            if(state.duration <= 0)
            {
                state.OnRemoved();
                currentStates.Remove(state);
            }
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
                    Debug.Log("hit");

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
