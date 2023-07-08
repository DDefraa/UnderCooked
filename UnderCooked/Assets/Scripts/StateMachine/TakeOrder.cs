using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TakeOrder : AIState
{
    


    public TakeOrder(NavMeshAgent _agent, GameObject _player, Transform _ordine, Transform _magazzino, Transform _cucina) : base(_agent, _player, _ordine, _magazzino, _cucina)
    {
        name = State.TakeOrder;
    }

    public override void Enter()
    {

        base.Enter();
        int pomodori = base.pomodori = 3;

        
    }
    public override void Update()
    {


        //Debug.Log("Andiamo a prendere l'ordine");

        
         
        agent.SetDestination(ordine.position);

        

        base.Update();

        if (Vector3.Distance(ordine.position, player.transform.position) < 2)
        {
            Debug.Log("ce sto");
            

            if (pomodori < 2)
            {
                

                nextState = new RestoreFood(agent, player, ordine, magazzino, cucina);
                stage = Event.Exit;
                return;

            }
            else
            {
                nextState = new GoKitchen(agent, player, ordine, magazzino, cucina);
                stage = Event.Exit;
                return;
            }
        }
    
        
    }

   


    public override void Exit()
    {
        base.Exit();
    }
}
