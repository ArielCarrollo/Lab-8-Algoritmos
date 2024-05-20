using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject groundprefab;
    public TextAsset maptxt;
    private string[] AllMapstring;
    private string[] CurrentlineString;
    public Vector2 initialPosition;
    public float Posseparation;
    private void Awake()
    {
        if (maptxt != null)
        {
            AllMapstring = maptxt.text.Split('\n');
            for (int i = 0; i < AllMapstring.Length; i++)
            {
                CurrentlineString = AllMapstring[i].Split(',');
                for (int j = 0; j < CurrentlineString.Length; j++)
                {
                    Vector2 position = new Vector2(initialPosition.x + Posseparation * j, initialPosition.y - Posseparation *i);
                    GameObject tmp = Instantiate(groundprefab, position, transform.rotation);
                    tmp.transform.SetParent(this.gameObject.transform);
                }
            }
        }
    }
}
