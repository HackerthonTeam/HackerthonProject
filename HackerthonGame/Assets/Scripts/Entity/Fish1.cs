using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public enum Fish1State { Idle, Chase, Dead, Global}

[Serializable]
public class Fish1Data
{
    public float hp;
    public float speed;
    public float chaseDistance;
}

public class Fish1 : BaseEntity
{
    public Fish1Data fish1Data = new Fish1Data();
    public Fish1Data Fish1Data => fish1Data;
    State<Fish1>[] states;
    private StateMachine<Fish1> stateMachine;
    Player player;
    float lastHp;
    float lastDamaged;

    public Item dropItem;

    Animator animator;

    public void Awake()
    {
        Setup(gameObject.name);
    }

    private void Start()
    {
        fish1Data.hp = 15;
        fish1Data.speed = 0.5f;
        fish1Data.chaseDistance = 5;
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        animator = gameObject.AddComponent<Animator>();
    }

    public void Update()
    {
        stateMachine.Execute();

        if ((player.transform.position - transform.position).magnitude < Fish1Data.chaseDistance || fish1Data.hp != 15 && lastDamaged <= 10) ChangeState(Fish1State.Chase);
        else ChangeState(Fish1State.Idle);


        if(lastHp > fish1Data.hp)
        {
            lastDamaged = 0;
            lastHp = fish1Data.hp;
        }
        lastDamaged += Time.deltaTime;

    }

    public override void Setup(string name)
    {
        base.Setup(name);

        states = new State<Fish1>[System.Enum.GetValues(typeof(Fish1State)).Length];
        states[(int)Fish1State.Idle] = new Fish1States.Idle();
        states[(int)Fish1State.Chase] = new Fish1States.Chase();
        states[(int)Fish1State.Dead] = new Fish1States.Dead();
        states[(int)Fish1State.Global] = new Fish1States.GlobalState();

        stateMachine = new StateMachine<Fish1>();
        stateMachine.Setup(this, states[0]);

        stateMachine.SetGlobalState(states[(int)Fish1State.Global]);
    }

    public void ChangeState(Fish1State newState)
    {
        stateMachine.ChangeState(states[(int)newState]);
    }
}

namespace Fish1States
{
    public class Idle : State<Fish1>
    {
        float curTime = 0;
        float randWait;
        Vector2 movePos = Vector2.zero;
        Vector2 targetPos = Vector2.zero;
        public override void Enter(Fish1 entity)
        {
            randWait = UnityEngine.Random.Range(6f, 10f);
        }
        public override void Execute(Fish1 entity)
        {
            curTime += Time.deltaTime;
            if(curTime > randWait)
            {
                randWait = UnityEngine.Random.Range(6f, 10f);
                curTime = 0;
                movePos = Wander(entity.transform.position);
                targetPos = movePos + (Vector2) entity.transform.position;
            }

            if(movePos!= Vector2.zero)
            {
                Vector2 moveVector =  targetPos - (Vector2)entity.transform.position;
                if(moveVector.magnitude < 0.1f)
                {
                    movePos = Vector2.zero;
                }
                else entity.transform.position += (Vector3)movePos * Time.deltaTime * entity.Fish1Data.speed;
            }

            
        }
        public override void Exit(Fish1 entity)
        {

        }

        Vector2 Wander(Vector2 currentPos)
        {
            Vector2 movePos = Vector2.zero;
            int count = 0;
            while (count <= 10)
            {
                movePos = new Vector2(UnityEngine.Random.Range(-1, 2), UnityEngine.Random.Range(-1, 2));
                Collider2D[] cols = Physics2D.OverlapCircleAll(new Vector2(currentPos.x + movePos.x, currentPos.y + movePos.y), 0.1f);
                if (cols.Length == 1 && cols[0].gameObject.layer == 3)
                {
                    break;
                }
                count++;
            }

            return movePos;
        }
    }

    public class Chase : State<Fish1>
    {
        Player player;
        Vector2 movePos = Vector2.zero, targetPos = Vector2.zero;
        public override void Enter(Fish1 entity)
        {
            if(!player)
            {
                player = GameObject.FindWithTag("Player").GetComponent<Player>();
            }
        }
        public override void Execute(Fish1 entity)
        {
            Vector2 trackerVector = player.transform.position - entity.transform.position;
            targetPos = (Vector2)entity.transform.position + (trackerVector * -1).normalized;
            Collider2D[] cols = Physics2D.OverlapCircleAll(targetPos, 0.1f);
            if (cols.Length == 1 && cols[0].gameObject.layer == 4)
            {
                movePos = targetPos - (Vector2)entity.transform.position;
            }
            else movePos = Vector2.zero;

            if(movePos != Vector2.zero)
            {
                Vector2 moveVector = targetPos - (Vector2)entity.transform.position;
                if (moveVector.magnitude < 0.1f)
                {
                    movePos = Vector2.zero;
                }
                else entity.transform.position += (Vector3)movePos * Time.deltaTime * entity.Fish1Data.speed;
            }

        }
        public override void Exit(Fish1 entity)
        {

        }
    }

    public class Dead : State<Fish1>
    {
        public override void Enter(Fish1 entity)
        {
            entity.fish1Data.speed = 0;
            PoolManager.Instance.GetPool(entity.dropItem.gameObject, entity.transform.position, Quaternion.identity);
        }
        public override void Execute(Fish1 entity)
        {
            
        }
        public override void Exit(Fish1 entity)
        {

        }
    }

    public class GlobalState : State<Fish1>
    {
        public override void Enter(Fish1 entity)
        {

        }
        public override void Execute(Fish1 entity)
        {

        }
        public override void Exit(Fish1 entity)
        {

        }
    }
}

