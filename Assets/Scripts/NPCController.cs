using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCController : MonoBehaviour
{
    public float PatrolTime = 10f;
    public float AggroRange = 10f;
    public Transform[] Waypoints;

    private int _index;
    private float _speed;
    private float _agentSpeed;
    
    private Transform _playerTransform;
    private Animator _animator;
    private NavMeshAgent _agent;

    private void Awake()
    {
//        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        if (_agent != null)
        {
            _agentSpeed = _agent.speed;
        }

        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        _index = Random.Range(0, Waypoints.Length);
        
        InvokeRepeating(nameof(Tick), 0, 0.5f);

        if (Waypoints.Length > 0)
        {
            InvokeRepeating(nameof(Patrol), 0, PatrolTime);
        }
    }

    private void Patrol()
    {
        _index = _index == Waypoints.Length - 1 ? 0 : _index + 1;
    }

    private void Tick()
    {
        _agent.destination = Waypoints[_index].position;
        _agent.speed = _agentSpeed / 2;
        
        if (_playerTransform != null &&
            Vector3.Distance(transform.position, _playerTransform.position) < AggroRange)
        {
            _agent.destination = _playerTransform.position;
            _agent.speed = _agentSpeed;
        }
    }
}
