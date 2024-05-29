using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class NodeController : MonoBehaviour
{
    public NodeController[] adjacentNodes;
    public float energyCost = 1f;

    public void AddAdjacentNode(NodeController node)
    {
        for (int i = 0; i < adjacentNodes.Length; i++)
        {
            if (adjacentNodes[i] == null)
            {
                adjacentNodes[i] = node;
                return;
            }
        }
        Debug.LogWarning("No se puede agregar más nodos adyacentes, el array está lleno.");
    }

    public NodeController SelectNodeRandom()
    {
        if (adjacentNodes.Length == 0)
        {
            Debug.LogWarning("No Existen papi.");
            return null;
        }

        int index = Random.Range(0, adjacentNodes.Length);
        return adjacentNodes[index];
    }
}

