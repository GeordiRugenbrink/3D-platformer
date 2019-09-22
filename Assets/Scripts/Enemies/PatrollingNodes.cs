using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingNodes : MonoBehaviour
{
    public Transform[] patrolNodes;

    public Vector3 GetNextPatrolNode(Vector3 currentNodePosition) {
        if (patrolNodes.Length < 1) return Vector3.zero; //No nodes in the array
        bool currentPositionWasFound = false;
        foreach(Transform patrolNode in patrolNodes) {
            if (currentPositionWasFound) {
                return patrolNode.position;
            }
            if(Vector3.Distance(patrolNode.position, currentNodePosition) < 1f) {
                currentPositionWasFound = true;
            }
        }
        return patrolNodes[0].position; //If none are found return the first node
    }
}
