using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerView
{
    public GameObject View {get; private set;}
    public NavMeshAgent NavAgent {get; private set;} 

    public PlayerView(GameObject view, NavMeshAgent navAgent)
    {
        View = view;
        NavAgent = navAgent;
    }
}
