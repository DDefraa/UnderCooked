using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Idle : AIState
{
    public GameObject gameObject;

    public Idle(NavMeshAgent _agent, GameObject _player, Transform _ordine, Transform _magazzino, Transform _cucina, GameObject _piatto, Transform _rifPizza, Transform _rifLasagna, Transform _rifPasta) : base(_agent, _player, _ordine, _magazzino, _cucina, _piatto, _rifPizza, _rifLasagna, _rifPasta)
    {
        name = State.Idle;

        this.ordine = _ordine;
        this.magazzino = _magazzino; 
        this.cucina = _cucina;
        this.piatto = _piatto;
        this.rifPizza = _rifPizza;
        this.rifLasagna = _rifLasagna;
        this.rifPasta = _rifPasta;
        
    }

    //public Idle(NavMeshAgent agent, GameObject gameObject, Transform ordine, Transform magazzino)
    //{
    //    this.agent = agent;
    //    this.gameObject = gameObject;
    //    this.ordine = ordine;
    //    this.magazzino = magazzino;
    //}

    public override void Enter()
    {
        base.Enter();
        
        
    }
    public override void Update()
    {
        base.Update();

        agent.SetDestination(Vector3.zero);

        if(Vector3.Distance(Vector3.zero, player.transform.position) < 2)
        {
            nextState = new TakeOrder(agent, player, ordine, magazzino, cucina, piatto, rifPizza, rifLasagna, rifPasta);
            stage = Event.Exit;
            return;
        }

    }
    public override void Exit()
    {
        base.Exit();
    }

}

