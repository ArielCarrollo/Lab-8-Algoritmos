using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphControl : MonoBehaviour
{
    public GameObject Nodeprefab;
    public TextAsset NodePositiontext;
    public string[] arrayNodePosition;
    public string[] currentNodePositions;

    public List<GameObject> allnodes;
    public TextAsset nodeConectiontxt;
    public string[] arrayNodeConection;
    public string[] CurrentNodeConextions;
    public EnemyController Enemy;
    void Start()
    {
        createnode();
        CreateConections();
        selecInitialNode();
        allnodes[2].GetComponent<NodeController>().energyCost = 3f;
        allnodes[3].GetComponent<NodeController>().energyCost = 5f;
    }
    void createnode()
    {
        if (NodePositiontext != null)
        {
            arrayNodePosition = NodePositiontext.text.Split('\n');
            for (int i = 0; i < arrayNodePosition.Length; i++)
            {
                currentNodePositions = arrayNodePosition[i].Split(',');
                Vector2 positionn = new Vector2(float.Parse(currentNodePositions[0]), float.Parse(currentNodePositions[1]));
                GameObject tmp = Instantiate(Nodeprefab, positionn, transform.rotation);
                allnodes.Add(tmp);
            }
        }
    }
    void CreateConections()
    {
        if (nodeConectiontxt != null)
        {
            arrayNodeConection = nodeConectiontxt.text.Split('\n');
            for (int i = 0; i < arrayNodeConection.Length; i++)
            {
                CurrentNodeConextions = arrayNodeConection[i].Split(',');
                for (int j = 0; j < CurrentNodeConextions.Length; ++j)
                {
                    allnodes[i].GetComponent<NodeController>().AddjacentNode(allnodes[int.Parse(CurrentNodeConextions[j])].GetComponent<NodeController>());
                }
            }

        }
    }
    void selecInitialNode()
    {
        int index = Random.Range(0, allnodes.Count);
        Enemy.objective = allnodes[index];
    }
}
