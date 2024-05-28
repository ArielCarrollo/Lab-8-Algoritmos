using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class NodeController : MonoBehaviour
{
    public SimplyLinkedList<GameObject> adjacentNodes = new SimplyLinkedList<GameObject>();
    public float energyCost = 1f;

    public void AddAdjacentNode(GameObject node)
    {
        adjacentNodes.InsertNodeAtEnd(node);
    }

    public GameObject SelectNodeRandom()
    {
        if (adjacentNodes == null || adjacentNodes.length == 0)
        {
            return null; 
        }
        else
        {
            int index = UnityEngine.Random.Range(0, adjacentNodes.length);
            return adjacentNodes.ObtainNodeAtPosition(index);
        }
    }
}

