using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : Node {
    //The child nodes for this selector
    protected List<Node> nodes = new List<Node>();

    public Selector(List<Node> nodes) {
        this.nodes = nodes;
    }

    /// <summary>
    /// If one of the children reports a succes, the selector will report it upwards.
    /// If all children fail it will report a failure instead.
    /// </summary>
    /// <returns>It returns a nodestate that can be used to see what node needs to be executed.</returns>
    public override NodeStates Evaluate() {
        foreach(Node node in nodes) {
            switch (node.Evaluate()) {
                case NodeStates.FAILURE:
                    continue;
                case NodeStates.SUCCESS:
                    nodeState = NodeStates.SUCCESS;
                    return nodeState;
                case NodeStates.RUNNING:
                    nodeState = NodeStates.RUNNING;
                    return nodeState;
                default:
                    continue;
            }
        }
        nodeState = NodeStates.FAILURE;
        return nodeState;
    }
}
