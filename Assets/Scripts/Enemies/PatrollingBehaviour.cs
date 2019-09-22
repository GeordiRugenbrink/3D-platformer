using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PatrollingBehaviour : MonoBehaviour {

    private NavMeshAgent agent;

    private void Start() {
        agent = GetComponent<NavMeshAgent>();
    }

    public bool HasArrived() {
        if (!agent.pathPending) {
            if(agent.pathStatus == NavMeshPathStatus.PathComplete) {
                float remainingDistance = agent.remainingDistance;
                return (agent.remainingDistance <= agent.stoppingDistance);
            }
        }
        return false;
    }

    public void SetTarget(Vector3 target) {
        Debug.Log(agent.destination);
        agent.SetDestination(target);
        agent.isStopped = false;
    }

    public void StopWalking() {
        agent.isStopped = true;
    }
}
