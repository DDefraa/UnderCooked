using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RestoreFood : AIState
{
    public RestoreFood(NavMeshAgent _agent, GameObject _player, Transform _ordine, Transform _magazzino, Transform _cucina, GameObject _piatto, Transform _rifPizza, Transform _rifLasagna, Transform _rifPasta) : base(_agent, _player, _ordine, _magazzino, _cucina, _piatto, _rifPizza, _rifLasagna, _rifPasta)
    {
        name = State.RestoreFood;
    }

   public override void Enter()
    {
        base.Enter();
        
    }
    public override void Update()
    {
        base.Update();
        
        agent.SetDestination(magazzino.position);
        
        

        if(Vector3.Distance(magazzino.position, player.transform.position) < 2) 
        {
            Debug.Log("Cuciniamo con nuovi ing");
            nextState = new GoKitchen(agent, player, ordine, magazzino, cucina, piatto, rifPizza, rifLasagna, rifPasta);
            stage = Event.Exit;
            return;
        }
    }
    public override void Exit()
    {
        base.Exit();
    }
}
