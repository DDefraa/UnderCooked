using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.AI;

public class TakeOrder : AIState
{
    

    public TakeOrder(NavMeshAgent _agent, GameObject _player, Transform _ordine, Transform _magazzino, Transform _cucina, GameObject _piatto, Transform _rifPizza, Transform _rifLasagna, Transform _rifPasta) : base(_agent, _player, _ordine, _magazzino, _cucina, _piatto, _rifPizza, _rifLasagna, _rifPasta)
    {
        name = State.TakeOrder;
    }

    bool ordinare;
    bool conferma;
    bool next;

    int scelta;
    float timer;

    public override void Enter()
    {
       

        base.Enter();

        conferma = false;
        next = false;
        timer = 2;
        scelta = UnityEngine.Random.Range(0, 3);


        

    }


    public override void Update()
    {
        agent.SetDestination(ordine.position);
        if (Vector3.Distance(ordine.position, player.transform.position) < 2f)
        {
            ordinare = true;
            Debug.Log("si può ordinare");

        }
        //agent.SetDestination(ordine.position);

        base.Update();

            if (ordinare)
            {
                timer += Time.deltaTime;
                SceltaOrdine(scelta);
                
                conferma = true;
            }
            if (conferma)
            {
                
                ordinare = false;
                nextState = new GoKitchen(agent, player, ordine, magazzino, cucina, piatto, rifPizza, rifLasagna, rifPasta);
                stage = Event.Exit;
                
                
            }
        //if (!Pronto())
        //{
        //}

            if (Vector3.Distance(ordine.position, player.transform.position) < 2)
            {
                timer += Time.deltaTime;
                
                if (timer >= 2.5)
                {
                    next = true;
                }
            }
        //if (Pronto())
        //{
        //}

            if (next)
            {
             //piatto.name = "Ordine";

             agent.SetDestination(Vector3.zero);
             nextState = new Idle(agent, player, ordine, magazzino, cucina, piatto, rifPizza, rifLasagna, rifPasta);
             stage = Event.Exit;
             return;
            }





        //if (Vector3.Distance(ordine.position, player.transform.position) < 2)
        //{
        //    Debug.Log("ce sto");
            

        //        nextState = new RestoreFood(agent, player, ordine, magazzino, cucina, piatto, rifPizza, rifLasagna, rifPasta);
        //        stage = Event.Exit;
        //        return;

        //}
    
        
    }

    void SceltaOrdine(int n)
    {
        switch (n)
        {
            case 0:
                piatto.name = "Pizza";
                break;
            case 1:
                piatto.name = "Lasagna";
                break;
            case 2:
                piatto.name = "Pasta";
                break;
        }
    }




    public override void Exit()
    {
        base.Exit();
        
    }
}
