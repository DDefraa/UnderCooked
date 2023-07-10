using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TakeOrder : AIState
{

    public enum DishType
    {
        Pizza,
        Lasagna,
        Pasta,
        vuoto
    }

    public static DishType scelta;







    public TakeOrder(NavMeshAgent _agent, GameObject _player, Transform _ordine, Transform _consegna, Transform _cucina, GameObject _piatto, Transform _rifPizza, Transform _rifLasagna, Transform _rifPasta) : base(_agent, _player, _ordine, _consegna, _cucina, _piatto, _rifPizza, _rifLasagna, _rifPasta)
    {
        name = State.TakeOrder;
    }

    public override void Enter()
    {

        scelta = (DishType)UnityEngine.Random.Range(0, 3);
        Debug.Log(scelta);
        agent.SetDestination(ordine.position);

        //int numero = RestoreFood.num;
        base.Enter();

    }

    public override void Update()
    {



        base.Update();

        if (Vector3.Distance(ordine.position, player.transform.position) < 2)
        {







            if (Inventario.current.patate == 0 || Inventario.current.pomodori == 0 && scelta == DishType.Pizza)
            {

                nextState = new RestoreFood(agent, player, ordine, consegna, cucina, piatto, rifPizza, rifLasagna, rifPasta);
                stage = Event.Exit;


                Debug.Log("Mancano Ing.Pizza");

            }
            else
            {
                nextState = new GoKitchen(agent, player, ordine, consegna, cucina, piatto, rifPizza, rifLasagna, rifPasta);
                stage = Event.Exit;
                Debug.Log("Andiamo a fare la Pizza");
                return;

            }






            if (Inventario.current.carote == 0 || Inventario.current.patate == 0 && scelta == DishType.Pasta)
            {

                nextState = new RestoreFood(agent, player, ordine, consegna, cucina, piatto, rifPizza, rifLasagna, rifPasta);
                stage = Event.Exit;
                //return;

                Debug.Log("Mancano Ing.Pasta");
            }
            else
            {
                nextState = new GoKitchen(agent, player, ordine, consegna, cucina, piatto, rifPizza, rifLasagna, rifPasta);
                stage = Event.Exit;
                Debug.Log("Andiamo a fare la pasta");
                return;

            }





            if (Inventario.current.pomodori == 0 || Inventario.current.carote == 0 && scelta == DishType.Lasagna)
            {

                nextState = new RestoreFood(agent, player, ordine, consegna, cucina, piatto, rifPizza, rifLasagna, rifPasta);
                stage = Event.Exit;


                Debug.Log("Mancano Ing.Lasagne");

            }
            else
            {
                nextState = new GoKitchen(agent, player, ordine, consegna, cucina, piatto, rifPizza, rifLasagna, rifPasta);
                stage = Event.Exit;
                Debug.Log("Andiamo a fare le lasagne");
                return;

            }




        }






    }



    public override void Exit()
    {
        base.Exit();
    }
}
