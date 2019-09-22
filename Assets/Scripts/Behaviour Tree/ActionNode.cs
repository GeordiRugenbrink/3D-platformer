using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionNode : Node {

    public delegate NodeStates ActionNodeDelegate();

    private ActionNodeDelegate action;

    public ActionNode(ActionNodeDelegate action) {
        this.action = action;
    }

    public override NodeStates Evaluate() {
        switch (action()) {
            case NodeStates.SUCCESS:
                nodeState = NodeStates.SUCCESS;
                return nodeState;
            case NodeStates.FAILURE:
                nodeState = NodeStates.FAILURE;
                return nodeState;
            case NodeStates.RUNNING:
                nodeState = NodeStates.RUNNING;
                return nodeState;
            default:
                nodeState = NodeStates.FAILURE;
                return nodeState;
        }
    }
}
