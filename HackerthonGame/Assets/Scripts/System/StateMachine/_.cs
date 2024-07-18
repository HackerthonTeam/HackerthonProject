using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum _State { Idle, Walk, Global}

[Serializable]
public class _Data
{
    //데이터들
}

public class _ : BaseEntity
{
    public _Data _Data { get; private set; }
    State<_>[] states;
    private StateMachine<_> stateMachine;

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

        states = new State<_>[System.Enum.GetValues(typeof(_State)).Length];
        states[(int)_State.Idle] = new _States.Idle();
        states[(int)_State.Walk] = new _States.Walk();
        states[(int)_State.Global] = new _States.GlobalState();

        stateMachine = new StateMachine<_>();
        stateMachine.Setup(this, states[0]);

        stateMachine.SetGlobalState(states[(int)_State.Global]);
    }

    public void ChangeState(_State newState)
    {
        stateMachine.ChangeState(states[(int)newState]);
    }
}

namespace _States
{
    public class Idle : State<_>
    {
        public override void Enter(_ entity)
        {

        }
        public override void Execute(_ entity)
        {

        }
        public override void Exit(_ entity)
        {

        }
    }

    public class Walk : State<_>
    {
        public override void Enter(_ entity)
        {

        }
        public override void Execute(_ entity)
        {

        }
        public override void Exit(_ entity)
        {

        }
    }

    public class GlobalState : State<_>
    {
        public override void Enter(_ entity)
        {

        }
        public override void Execute(_ entity)
        {

        }
        public override void Exit(_ entity)
        {

        }
    }
}

