using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TakeOrder : AIState
{
    public TakeOrder(NavMeshAgent _agent, GameObject _player, Transform _ordine) : base(_agent, _player, _ordine)
    {
        name = State.TakeOrder;
    }

    public override void Enter()
    {
        base.Enter();
    }
    public override void Update()
    {
        Debug.Log("Andiamo a prendere l'ordine");
        agent.SetDestination(ordine.position);
        base.Update();
    }
    public override void Exit()
    {
        base.Exit();
    }
}
