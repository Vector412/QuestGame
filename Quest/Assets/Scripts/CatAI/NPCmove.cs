using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCmove : MonoBehaviour
{
    [SerializeField]
    Transform _destination;
    [SerializeField]
    Animator anim;

    NavMeshAgent _navMeshAgent;

    private void Start()
    {
        _navMeshAgent = this.GetComponent<NavMeshAgent>();
        if(_navMeshAgent == null)
        {
            Debug.LogError("The nav mesh agent component isn't attached to " + gameObject.name);
        }
        else
        {
            SetDestination();
        }
    }

    private void SetDestination()
    {
        if (_destination != null)
        {
            anim.SetBool("isWalking", true);
            Vector3 targetVector = _destination.transform.position;
            _navMeshAgent.SetDestination(targetVector);         
             anim.SetBool("isWalking", false);    
            
        }

    }
}
