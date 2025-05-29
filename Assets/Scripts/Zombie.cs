using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private CapsuleCollider _capsuleCollider;
    [SerializeField] private MovementAnimator _movement;
    [SerializeField] private Animator _animator;
    [SerializeField] private ParticleSystem _particleSystem;

    private Player _player;
    private Counter _counter;
    private bool dead;

    void Start()
    {
        _player = FindObjectOfType<Player>();
        _counter = FindObjectOfType<Counter>();

        
        _navMeshAgent.updateRotation = false;
    }

    void Update()
    {
        if (dead)
            return;

        _navMeshAgent.SetDestination(_player.transform.position);

        if (_navMeshAgent.velocity.sqrMagnitude > 0.1f)
        {
            
            Vector3 moveDirection = _navMeshAgent.velocity.normalized;
            moveDirection.y = 0; 

           
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDirection), Time.deltaTime * 5f);
        }
    }

    public void Kill()
    {
        if (!dead)
        {
            dead = true;
            _particleSystem.Play();
            _counter.AddKill();
            _capsuleCollider.enabled = false;
            _movement.enabled = false;
            _navMeshAgent.enabled = false;
            Destroy(gameObject, 7.0f);
            _animator.SetTrigger("died");
        }
    }
}
