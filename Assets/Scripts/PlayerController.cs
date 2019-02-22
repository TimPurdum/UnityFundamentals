using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    //private Animator anim;
    private NavMeshAgent _agent;
    Animator _animator;
    static readonly int _speed = Animator.StringToHash("Speed");


    // Start is called before the first frame update
    void Awake()
    {
        _animator = GetComponent<Animator>();    
        _agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        _animator.SetFloat(_speed, _agent.velocity.magnitude);
    }
}
