using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class GoKitchen : AIState
{
    TakeOrder.DishType scelta;

    public GoKitchen(NavMeshAgent _agent, GameObject _player, Transform _ordine, Transform _consegna, Transform _cucina, GameObject _piatto, Transform _rifPizza, Transform _rifLasagna, Transform _rifPasta) : base(_agent, _player, _ordine, _consegna, _cucina, _piatto, _rifPizza, _rifLasagna, _rifPasta)
    {
        name = State.GoKitchen;
    }

    public override void Enter()
    {
        base.Enter();

        if (scelta == TakeOrder.DishType.Pizza)
        {
            Inventario.current.pomodori--;
            Inventario.current.patate--;
           
        }
        if (scelta == TakeOrder.DishType.Lasagna)
        {
            Inventario.current.pomodori--;
            Inventario.current.carote--;
           
        }
        if (scelta == TakeOrder.DishType.Pasta)
        {
            Inventario.current.carote--;
            Inventario.current.patate--;
            
        }

    }
    public override void Update()
    {
        base.Update();
        //Debug.Log("Cuciniamo");
        agent.SetDestination(cucina.position);

        if (Vector3.Distance(cucina.position, player.transform.position) < 2)
        {

            nextState = new DeliverPlate(agent, player, ordine, consegna, cucina, piatto, rifPizza, rifLasagna, rifPasta);
            stage = Event.Exit;
            return;
        }
    }
    public override void Exit()
    {
        base.Exit();
    }
}
