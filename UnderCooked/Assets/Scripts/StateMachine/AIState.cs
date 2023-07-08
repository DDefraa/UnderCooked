using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public enum State
{
    Idle,
    TakeOrder,
    RestoreFood,
    GoKitchen
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
    protected Transform magazzino;
    protected Transform cucina;

    protected int pomodori = 3;
   


    public AIState(NavMeshAgent _agent, GameObject _player, Transform _ordine, Transform _magazzino, Transform _cucina)
    {
        stage = Event.Enter;
       
        agent = _agent;
        
        player = _player;

        ordine = _ordine;

        magazzino = _magazzino;

        cucina = _cucina;
        
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