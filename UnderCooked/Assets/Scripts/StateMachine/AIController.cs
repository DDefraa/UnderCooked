using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{

    [SerializeField] Transform ordine;

    NavMeshAgent agent;

    AIState currentState;

    private void Start()
    {
        agent = transform.GetComponent<NavMeshAgent>();
        
        currentState = new Idle(agent, this.gameObject, ordine);
    }

    private void Update()
    {
        currentState = currentState.Process();
        //Debug.Log(currentState.name);
    }
}
