using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RestoreFood : AIState
{

    public static TakeOrder.DishType scelta;
    public static int num = 0;

    public RestoreFood(NavMeshAgent _agent, GameObject _player, Transform _ordine, Transform _consegna, Transform _cucina, GameObject _piatto, Transform _rifPizza, Transform _rifLasagna, Transform _rifPasta) : base(_agent, _player, _ordine, _consegna, _cucina, _piatto, _rifPizza, _rifLasagna, _rifPasta)
    {
        name = State.RestoreFood;
    }

    public override void Enter()
    {
        base.Enter();

       

        //if (scelta == TakeOrder.DishType.Pizza)
        //{
        //    num = 0;
        //    // agent.SetDestination(rifPizza.position);
        //    Debug.Log(num);
        //}
        //if (scelta == TakeOrder.DishType.Lasagna)
        //{
        //    num = 1;
        //    // agent.SetDestination(rifLasagna.position);
        //    Debug.Log(num);
        //}
        //if (scelta == TakeOrder.DishType.Pasta)
        //{
        //    num = 2;
        //    // agent.SetDestination(rifPasta.position);
        //    Debug.Log(num);
        //}
    }
    public override void Update()
    {
        base.Update();

        switch (scelta)
        {
            case TakeOrder.DishType.Pizza:
                Debug.Log(agent.transform.position);
                agent.SetDestination(rifPizza.position);

                if (Vector3.Distance(rifPizza.position, player.transform.position) < 2)
                {
                    Inventario.current.patate = 3;
                    Inventario.current.pomodori = 3;
                    Debug.Log("Cuciniamo la Pizza con nuovi ing");
                    nextState = new GoKitchen(agent, player, ordine, consegna, cucina, piatto, rifPizza, rifLasagna, rifPasta);
                    stage = Event.Exit;
                }
                break;

            case TakeOrder.DishType.Lasagna:
                Debug.Log(agent.transform.position);
                agent.SetDestination(rifLasagna.position);

                if (Vector3.Distance(rifLasagna.position, player.transform.position) < 2)
                {
                    Inventario.current.carote = 3;
                    Inventario.current.pomodori = 3;
                    Debug.Log("Cuciniamo la Lasagana con nuovi ing");
                    nextState = new GoKitchen(agent, player, ordine, consegna, cucina, piatto, rifPizza, rifLasagna, rifPasta);
                    stage = Event.Exit;
                }
                break;

            case TakeOrder.DishType.Pasta:
                Debug.Log(agent.transform.position);
                agent.SetDestination(rifPasta.position);

                if (Vector3.Distance(rifPasta.position, player.transform.position) < 2)
                {
                    Inventario.current.patate = 3;
                    Inventario.current.carote = 3;
                    Debug.Log("Cuciniamo la Pasta con nuovi ing");
                    nextState = new GoKitchen(agent, player, ordine, consegna, cucina, piatto, rifPizza, rifLasagna, rifPasta);
                    stage = Event.Exit;
                }
                break;
        }




    }
    public override void Exit()
    {
        base.Exit();
    }
}
