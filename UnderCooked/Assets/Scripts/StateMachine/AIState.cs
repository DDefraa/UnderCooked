using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum State
{
    Idle,
    TakeOrder
}

public enum Event
{
    Enter,
    Update,
    Exit
}


public class AIState
{
    public State name;
    protected Event stage;


    protected GameObject player;
    protected AIState nextState;
    protected NavMeshAgent agent;
    protected Transform ordine;
    

    public AIState(NavMeshAgent _agent, GameObject _player, Transform _ordine)
    {
        stage = Event.Enter;
       
        agent = _agent;
        
        player = _player;

        ordine = _ordine;
        
    }

    public virtual void Enter() { stage = Event.Update; }
    public virtual void Update() { /*stage = Event.Update;*/ }
    public virtual void Exit() { stage = Event.Exit; }

    public AIState Process()
    {
        if (stage == Event.Enter) Enter();
        else if (stage == Event.Update) Update();
        else if (stage == Event.Exit)
        {
            Exit();
            return nextState;
        }

        return this;
    }
}