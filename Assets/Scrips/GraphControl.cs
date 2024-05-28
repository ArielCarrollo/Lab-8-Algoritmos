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
            for (int i = 0; i < arrayNodeConnections.Length; i++)
            {
                string connections = arrayNodeConnections[i];
                string[] connectedNodes = connections.Split(',');

                int currentIndex = i; 
                for (int j = 0; j < connectedNodes.Length; j++)
                {
                    int connectedIndex = int.Parse(connectedNodes[j]);
                    if (connectedIndex != currentIndex && connectedIndex < allNodes.length)
                    {
                        GameObject currentNode = allNodes.ObtainNodeAtPosition(currentIndex);
                        GameObject connectedNode = allNodes.ObtainNodeAtPosition(connectedIndex);
                        currentNode.GetComponent<NodeController>().AddAdjacentNode(connectedNode);
                    }
                }
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
