using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Node 
{
    //Delegate that returns the state of the node
    public delegate NodeStates NodeReturn();

    //The current state of the node
    protected NodeStates nodeState;

    public NodeStates NodeState {
        get { return nodeState; }
    }

    //The constructor for the node
    public Node() { }

    //Implementing classes use this method to evaluate the desired set of conditions
    public abstract NodeStates Evaluate();
}
public enum NodeStates {
    FAILURE,
    RUNNING,
    SUCCESS
}
