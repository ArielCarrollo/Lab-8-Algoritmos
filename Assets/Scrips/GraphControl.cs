using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class GraphControl : MonoBehaviour
{
    public GameObject Nodeprefab;
    public TextAsset NodePositiontext;
    public TextAsset nodeConnectiontxt;
    public EnemyController Enemy;

    private SimplyLinkedList<GameObject> allNodes = new SimplyLinkedList<GameObject>();

    void Start()
    {
        CreateNodes();
        CreateConnections();
        SelectInitialNode();
        ModifyNodeCost();
    }

    void CreateNodes()
    {
        if (NodePositiontext != null)
        {
            string[] arrayNodePosition = NodePositiontext.text.Split('\n');
            foreach (string nodePosition in arrayNodePosition)
            {
                string[] coordinates = nodePosition.Split(',');
                Vector2 position = new Vector2(float.Parse(coordinates[0]), float.Parse(coordinates[1]));
                GameObject newNode = Instantiate(Nodeprefab, position, Quaternion.identity);
                allNodes.InsertNodeAtEnd(newNode);
            }
        }
    }

    void CreateConnections()
    {
        if (nodeConnectiontxt != null)
        {
            string[] arrayNodeConnections = nodeConnectiontxt.text.Split('\n');
            int index = 0;
            foreach (string connections in arrayNodeConnections)
            {
                string[] connectedNodes = connections.Split(',');
                foreach (string connectedNodeIndex in connectedNodes)
                {
                    int connectedIndex = int.Parse(connectedNodeIndex);
                    if (connectedIndex != index && connectedIndex < allNodes.length)
                    {
                        GameObject currentNode = allNodes.ObtainNodeAtPosition(index);
                        GameObject connectedNode = allNodes.ObtainNodeAtPosition(connectedIndex);
                        currentNode.GetComponent<NodeController>().AddAdjacentNode(connectedNode);
                    }
                }
                index++;
            }
        }
    }

    void SelectInitialNode()
    {
        if (allNodes.length > 0)
        {
            int index = Random.Range(0, allNodes.length);
            Enemy.objective = allNodes.ObtainNodeAtPosition(index);
        }
        else
        {
            Debug.LogWarning("No se han creado nodos para seleccionar uno inicialmente.");
        }
    }

    void ModifyNodeCost()
    {
        if (allNodes.length >= 4)
        {
            allNodes.ObtainNodeAtPosition(2).GetComponent<NodeController>().energyCost = 3f;
            allNodes.ObtainNodeAtPosition(3).GetComponent<NodeController>().energyCost = 5f;
        }
        else
        {
            Debug.LogWarning("No hay suficientes nodos para modificar los costos de energía.");
        }
    }
}
