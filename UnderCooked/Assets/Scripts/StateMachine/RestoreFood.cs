using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RestoreFood : AIState
{
    public RestoreFood(NavMeshAgent _agent, GameObject _player, Transform _ordine, Transform _magazzino, Transform _cucina) : base(_agent, _player, _ordine, _magazzino, _cucina)
    {
        name = State.RestoreFood;
    }

   public override void Enter()
    {
        base.Enter();
    }
    public override void Update()
    {
        //Debug.Log("Andiamo a prendere gli ingredienti");
        agent.SetDestination(magazzino.position);
        base.Update();
    }
    public override void Exit()
    {
        base.Exit();
    }
}
