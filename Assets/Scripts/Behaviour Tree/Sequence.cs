using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : Node
{
    private List<Node> nodes = new List<Node>();

    public Sequence(List<Node> nodes) {
        this.nodes = nodes;
    }

    /// <summary>
    /// If any child node returns a failure, the entire node fails. 
    /// When all nodes return a success, the node reports a success.
    /// </summary>
    /// <returns></returns>
    public override NodeStates Evaluate() {
        bool anyChildRunning = false;

        foreach(Node node in nodes) {
            switch (node.Evaluate()) {
                case NodeStates.FAILURE:
                    nodeState = NodeStates.FAILURE;
                    return nodeState;
                case NodeStates.SUCCESS:
                    continue;
                case NodeStates.RUNNING:
                    anyChildRunning = true;
                    continue;
                default:
                    nodeState = NodeStates.SUCCESS;
                    return nodeState;
            }
        }
        nodeState = anyChildRunning ? NodeStates.RUNNING : NodeStates.SUCCESS;
        return nodeState;
    }
}
