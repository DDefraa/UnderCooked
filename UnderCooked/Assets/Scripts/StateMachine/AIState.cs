using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public enum State
{
    Idle,
    TakeOrder,
    RestoreFood,
    GoKitchen
}

public enum Event
{
    Enter,
    Update,
    Exit
}


public class AIState
{
    public State name;
    protected Event stage;


    protected GameObject player;
    protected AIState nextState;
    protected NavMeshAgent agent;
    protected Transform ordine;
    protected Transform magazzino;
    protected Transform cucina;
    protected GameObject piatto;
    protected Transform rifPizza, rifLasagna, rifPasta;


    float secondi;
    float minuti;


    public AIState(NavMeshAgent _agent, GameObject _player, Transform _ordine, Transform _magazzino, Transform _cucina, GameObject _piatto, Transform _rifPizza, Transform _rifLasagna, Transform _rifPasta)
    {
        stage = Event.Enter;
       
        agent = _agent;
        
        player = _player;

        ordine = _ordine;

        magazzino = _magazzino;

        cucina = _cucina;

        piatto = _piatto;

        rifPizza = _rifPizza;

        rifLasagna = _rifLasagna;

        rifPasta = _rifPasta;

        
        
    }

    public virtual void Enter() { stage = Event.Update; }
    public virtual void Update() { /*stage = Event.Update;*/ }
    public virtual void Exit() { stage = Event.Exit; }

    public AIState Process()
    {
        if (stage == Event.Enter) Enter();
        else if (stage == Event.Update) Update();
        else if (stage == Event.Exit)
        {
            Exit();
            return nextState;
        }

        return this;
    }

    //#region Ordini

    //public bool Aperto()
    //{
    //    if (Giorno.current.minuti >= 20 && Giorno.current.minuti <= 24 || Giorno.current.minuti >= 0 && Giorno.current.minuti < 8)
    //    {
    //        return false;
    //    }
    //    else
    //        return true;
    //}

    //public bool Pronto()
    //{
    //    if (piatto.name == "Pronto")
    //    {
    //        return true;
    //    }
    //    else if (piatto.name == "Ordine")
    //    {
    //        return false;
    //    }

    //    return false;
    //}

    public bool IngrPizza()
    {
        if (Inventario.current.pomodori == 0 || Inventario.current.patate == 0)
        {
            return false;
        }
        return true;
    }

    public bool IngrLasagna()
    {
        if (Inventario.current.pomodori == 0 || Inventario.current.carote == 0)
        {
            return false;
        }
        return true;
    }

    public bool IngrPasta()
    {
        if (Inventario.current.patate == 0 || Inventario.current.carote == 0)
        {
            return false;
        }
        return true;
    }


    //#endregion




}