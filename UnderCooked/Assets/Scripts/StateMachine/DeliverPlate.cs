using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static TakeOrder;

public class DeliverPlate : AIState
{
    public DeliverPlate(NavMeshAgent _agent, GameObject _player, Transform _ordine, Transform _consegna, Transform _cucina, GameObject _piatto, Transform _rifPizza, Transform _rifLasagna, Transform _rifPasta) : base(_agent, _player, _ordine, _consegna, _cucina, _piatto, _rifPizza, _rifLasagna, _rifPasta)
    {
        name = State.DeliverPlate;
    }
    public override void Enter()
    {
        base.Enter();



    }

    public override void Update()
    {
        agent.SetDestination(consegna.position);
        base.Update();

        if (Vector3.Distance(consegna.position, player.transform.position) < 2)
        {
            nextState = new Idle(agent, player, ordine, consegna, cucina, piatto, rifPizza, rifLasagna, rifPasta);
            stage = Event.Exit;
            return;
        }






    }



    public override void Exit()
    {
        base.Exit();
    }
}
