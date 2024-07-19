using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;
[Serializable]
public class PlayerData
{
    [SerializeField] private float health = 100;
    public float Health { get => health; set { health = Mathf.Clamp(value, 0, 100); } }

    [SerializeField] private float moveSpeed;
    public float MoveSpeed {get => moveSpeed; set { moveSpeed = Mathf.Clamp(value, 0, 100); } }

    [SerializeField] private float stemina = 100;
    public float Stemina { get => stemina; set { stemina = Mathf.Clamp(value, 0, 100); } }

    [SerializeField] private float temperature = 30;
    public float Temperature { get => temperature; set { temperature = Mathf.Clamp(value, 0, 100); } }

    [SerializeField] private float hunger = 80;
    public float Hunger { get => hunger; set { hunger = Mathf.Clamp(value, 0, 100); } }
}

public class Player : MonoBehaviour
{
    [SerializeField] PlayerData playerData = new();
    public PlayerData PlayerData => playerData;

    public List<SpecialState> currentStates = new List<SpecialState>(); 
    public List<SpecialState> addedStates = new List<SpecialState>(); 
    public float radius = 3f;        
    public int numberOfRays = 20;    
    private float angleStep;
    private float time = 3f;
    private bool AttCool = true;
    private Vector2 dis = new Vector2();

    public Image hpUi;
    public Image staminaUi;
    public Image hungerUi;
    public Image temperatureUi;
private float j=0;
    Animator animator;
    bool isatt = false;

    void Start()
    {
        angleStep = 180f / numberOfRays; // ����ĳ��Ʈ ���� ���� ���
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        attack();  // ���� ������ ����
        castRays();// ����ĳ��Ʈ�� �߻�
        time +=  Time.deltaTime;
        
        
        if(time >= 3 && isatt)
        {
            AttCool = true;
            time = 0;
        }

        ManageState();
        Reduce();
        UpdateUi();
    }

    void Reduce()
    {
        playerData.Hunger -= 0.002f;
        playerData.Stemina += 0.01f;
        playerData.Health += 0.005f;

        if(playerData.Temperature > 60)
        {
            int rand = UnityEngine.Random.Range(0, 100);
            if(rand == 0)
            {
                addedStates.Add(new Cold());
            }
        }
        if(IsOnWater())
        {
            playerData.Temperature += 0.05f;
        }
        if(playerData.Hunger <= 10)
        {
            playerData.Health -= 0.01f;
        }
        if(playerData.Temperature > 80)
        {
            playerData.Health -= 0.01f;
        }
    }

    bool IsOnWater()
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, 0.1f);
        if(cols.Length == 1 && cols[0].gameObject.layer == 4)
        {
            return true;
        }
        return false;
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
            dis = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // �÷��̾��� ������ ���콺 ��ġ�� �������� ȸ��
            //transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(dis.y, dis.x) * Mathf.Rad2Deg);
            
        }
    }
    

    private void castRays()
    {
        
        if (Input.GetMouseButtonDown(0) && AttCool)
        {
            isatt = true;
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 directionToMouse = (mousePosition - transform.position).normalized;

            float baseAngle = Mathf.Atan2(directionToMouse.y, directionToMouse.x) * Mathf.Rad2Deg;
            if (baseAngle < 0) baseAngle += 360;
            Vector2 MouseAngle = GetDirectionFromAngle(baseAngle);
            animator.SetFloat("PosX",MouseAngle.x);
            animator.SetFloat("PosY",MouseAngle.y);
            animator.SetBool("IsAttack", true);
            
            
            for (int i = 0; i < numberOfRays; i++)
            {
                float angle = baseAngle + (-numberOfRays / 2 + i) * angleStep;
                Vector3 direction = Quaternion.Euler(0, 0, angle) * Vector3.right;

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
    Vector2 GetDirectionFromAngle(float angle)
    {
        float radian = angle * Mathf.Deg2Rad;
        float x = Mathf.Cos(radian);
        float y = Mathf.Sin(radian);
        return new Vector2(Mathf.Round(x), Mathf.Round(y));
    }

    void UpdateUi()
    {
        hpUi.color = new Color(255, 255, 255, 1 * (playerData.Health / 100));
        staminaUi.color = new Color(255, 255, 255, 1 * (playerData.Stemina / 100));
        hungerUi.color = new Color(255, 255, 255, 1 * (playerData.Hunger / 100));
        temperatureUi.color = new Color(1 -  (playerData.Temperature / 100), 255, 255, 1);
    }
}
