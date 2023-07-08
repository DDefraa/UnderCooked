using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class GoKitchen : AIState
{
    public GoKitchen(NavMeshAgent _agent, GameObject _player, Transform _ordine, Transform _magazzino, Transform _cucina) : base(_agent, _player, _ordine, _magazzino, _cucina)
    {
        name = State.GoKitchen;
    }

    public override void Enter()
    {
        base.Enter();
    }
    public override void Update()
    {
        //Debug.Log("Cuciniamo");
        agent.SetDestination(cucina.position);
        base.Update();
    }
    public override void Exit()
    {
        base.Exit();
    }
}
