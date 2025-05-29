using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementAnimator : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;

    private Animator _animator;
    
    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetFloat("speed", _navMeshAgent.velocity.magnitude);
    }
}
