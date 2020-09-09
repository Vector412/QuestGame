using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCpatrol : MonoBehaviour
{

    [SerializeField]
    bool _patrolWaiting;
    [SerializeField]
    float _totalWaitTime = 3f;
    [SerializeField]
    float _switchProbability = 0.2f;
    [SerializeField]
    List<WayPoint> _patrolPoints = new List<WayPoint>();
    [SerializeField]
    Animator anim;
    NavMeshAgent _navMeshAgent;
    int _currentPatrolIndex;
    bool _travelling;
    bool _waiting;
    bool _patrolForward;
    float _waitTimer;


    private void Start()
    {
        _navMeshAgent = this.GetComponent<NavMeshAgent>();
        if (_navMeshAgent == null)
        {
            Debug.LogError("The nav mesh agent component isn't attached to " + gameObject.name);
        }
        else if(_patrolPoints != null && _patrolPoints.Count >= 2)
        {
            _currentPatrolIndex = 0;
            SetDestination();
        }
        else
        {
            Debug.Log("Insufficient patrol points for basic patrolling behaviour");
        }
    }

    private void Update()
    {
        if(_travelling && _navMeshAgent.remainingDistance <= 1.0f)
        {
            _travelling = false;
           
            if (_patrolWaiting)
            {
                _waiting = true;
                _waitTimer = 0f;
            }
            else
            {
                ChangePatrolPoint();
                SetDestination();
            }
        }
        if (_waiting)
        {
            _waitTimer += Time.deltaTime;
            anim.SetBool("isWalking", false);
            if (_waitTimer >= _totalWaitTime)
            {            
                ChangePatrolPoint();
                SetDestination();
            }
        }

    }

    private void SetDestination()
    {
        if(_patrolPoints != null)
        {
            Vector3 targetVector = _patrolPoints[_currentPatrolIndex].transform.position;
            _navMeshAgent.SetDestination(targetVector);
            _travelling = true;
            anim.SetBool("isWalking", true);
        }
    }
    private void ChangePatrolPoint()
    {
        if(Random.Range(0f,1f)<= _switchProbability)
        {
            _patrolForward = !_patrolForward;
        }
        if (_patrolForward)
        {
            _currentPatrolIndex = (_currentPatrolIndex + 1) % _patrolPoints.Count;
        }
        else
        {
            if(--_currentPatrolIndex < 0)
            {
                _currentPatrolIndex = _patrolPoints.Count - 1;
            }
        }
    }
}
