using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{

    [SerializeField] Transform ordine;
    [SerializeField] Transform magazzino;
    [SerializeField] Transform cucina;

    NavMeshAgent agent;

    AIState currentState;



    private void Start()
    {
        agent = transform.GetComponent<NavMeshAgent>();
        
        currentState = new Idle(agent, this.gameObject, ordine, magazzino, cucina);
    }

    private void Update()
    {
        currentState = currentState.Process();
        //Debug.Log(currentState.name);
    }

    
}
