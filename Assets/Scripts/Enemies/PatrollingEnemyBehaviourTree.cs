using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PatrollingAI))]
public class PatrollingEnemyBehaviourTree : MonoBehaviour, IBehaviourTree
{
    private Node treeNode;

    private Sequence patrolSequence;

    private PatrollingAI patrollingAI;

    private void Start()
    {
        patrollingAI = GetComponent<PatrollingAI>();

        CreateBehaviourTree();
        StartCoroutine(EvaluateTree());
    }

    public IEnumerator EvaluateTree() {
            yield return null;
            treeNode.Evaluate();
    }

    public void CreateBehaviourTree() {
        treeNode = new Selector(new List<Node> {
            new Sequence(new List<Node> {
                new ActionNode(patrollingAI.GetNextTarget),
                new ActionNode(patrollingAI.WalkTotarget)
            })
        });
    }
}
