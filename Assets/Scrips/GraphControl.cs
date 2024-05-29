using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class GraphControl : MonoBehaviour
{
    public GameObject NodePrefab;
    public TextAsset NodePositionText;
    public TextAsset NodeConnectionText;
    public EnemyController Enemy;

    private NodeController[] allNodes;

    void Start()
    {
        CreateNodes();
        CreateConnections();
        SelectInitialNode();
       
    }

    void CreateNodes()
    {
        if (NodePositionText != null)
        {
            string[] nodePositions = NodePositionText.text.Split('\n');
            allNodes = new NodeController[nodePositions.Length];
            for (int i = 0; i < nodePositions.Length; i++)
            {
                string[] coordinates = nodePositions[i].Split(',');
                float xCoord = float.Parse(coordinates[0]);
                float yCoord = float.Parse(coordinates[1]);
                Vector2 position = new Vector2(xCoord, yCoord);
                GameObject newNode = Instantiate(NodePrefab, position, Quaternion.identity);
                allNodes[i] = newNode.GetComponent<NodeController>();
            }
        }
    }

    void CreateConnections()
    {
        if (NodeConnectionText != null)
        {
            string[] nodeConnections = NodeConnectionText.text.Split('\n');
            for (int i = 0; i < nodeConnections.Length; i++)
            {
                string[] connectedNodes = nodeConnections[i].Split(',');

                for (int j = 0; j < connectedNodes.Length; j++)
                {
                    int connectedIndex = int.Parse(connectedNodes[j]);
                    if (connectedIndex != i && connectedIndex < allNodes.Length)
                    {
                        allNodes[i].AddAdjacentNode(allNodes[connectedIndex]);
                    }
                }
            }
        }
    }

    void SelectInitialNode()
    {
        if (allNodes.Length > 0)
        {
            int index = Random.Range(0, allNodes.Length);
            Enemy.objective = allNodes[index].gameObject;
        }
    }

   
}
