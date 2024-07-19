using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Fish1State { Idle, Walk, Global}

[Serializable]
public class Fish1Data
{
    //데이터들
}

public class Fish1 : BaseEntity
{
    public Fish1Data Fish1Data { get; private set; }
    State<Fish1>[] states;
    private StateMachine<Fish1> stateMachine;

    public void Awake()
    {
        Setup(gameObject.name);
    }

    public void Update()
    {
        stateMachine.Execute();



    }

    public override void Setup(string name)
    {
        base.Setup(name);

        states = new State<Fish1>[System.Enum.GetValues(typeof(Fish1State)).Length];
        states[(int)Fish1State.Idle] = new Fish1States.Idle();
        states[(int)Fish1State.Walk] = new Fish1States.Walk();
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

    public class Walk : State<Fish1>
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

