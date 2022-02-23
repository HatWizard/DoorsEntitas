using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleAnimator : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Animator _animator;

    private void Update() 
    {
        _animator.SetFloat("MoveSpeed", _agent.velocity.magnitude);
    }
}
