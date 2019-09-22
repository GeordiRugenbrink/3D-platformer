using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inverter : Node
{
    private Node node;

    public Node NodeP {
        get { return node; }
    }

    public Inverter(Node node) {
        this.node = node;
    }

    /// <summary>
    /// Inverts the result of the node,
    /// so a failure becomes a success and a success becomes a failure.
    /// </summary>
    /// <returns></returns>
    public override NodeStates Evaluate() {
        switch (node.Evaluate()) {
            case NodeStates.FAILURE:
                nodeState = NodeStates.SUCCESS;
                return nodeState;
            case NodeStates.RUNNING:
                nodeState = NodeStates.RUNNING;
                return nodeState;
            case NodeStates.SUCCESS:
                nodeState = NodeStates.FAILURE;
                return nodeState;
        }
        nodeState = NodeStates.SUCCESS;
        return nodeState;
    }
}
