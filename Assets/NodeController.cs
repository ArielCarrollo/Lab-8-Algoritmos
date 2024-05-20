using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeController : MonoBehaviour
{
    public List<NodeController> adjacentnodes;
    public float energyCost = 1f;

    public void AddjacentNode(NodeController node)
    {
        adjacentnodes.Add(node);

    }
    public NodeController SelecNodeRandom()
    {
        int index = Random.Range(0, adjacentnodes.Count);
        return adjacentnodes[index];
    }
}
