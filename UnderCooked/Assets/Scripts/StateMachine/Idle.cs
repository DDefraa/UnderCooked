using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Idle : AIState
{
    public Idle(NavMeshAgent _agent, GameObject _player, Transform _ordine) : base(_agent, _player, _ordine)
    {

        name = State.Idle;

    }

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

            nextState = new TakeOrder(agent, player, ordine);
            stage = Event.Exit;
            return;
        }

    }
    public override void Exit()
    {
        base.Exit();
    }

}

