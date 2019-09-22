using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PatrollingBehaviour))]
public class PatrollingAI : MonoBehaviour
{
    public PatrollingNodes patrollingNodes;

    private PatrollingBehaviour patrollingBehaviour;

    private void Start() {
        Debug.Assert(patrollingNodes != null);
        patrollingBehaviour = GetComponent<PatrollingBehaviour>();
    }

    public NodeStates GetNextTarget() {
        patrollingBehaviour.SetTarget(patrollingNodes.GetNextPatrolNode(transform.position));
        //TODO add animation here
        return NodeStates.SUCCESS;
    }

    public NodeStates WalkTotarget() {
        if (patrollingBehaviour.HasArrived()) return NodeStates.SUCCESS;
        return NodeStates.RUNNING;
    }
}
