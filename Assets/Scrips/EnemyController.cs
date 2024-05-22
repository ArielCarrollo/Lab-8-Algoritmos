using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject objective;
    public Vector2 speedReference;
    public float energy = 10f;
    private bool repos = false;
    private float restTime = 5f;
    private void Update()
    {
        if (!repos && energy > 0)
        {
            transform.position = Vector2.SmoothDamp(transform.position, objective.transform.position,ref speedReference, 0.5f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
     {
      if (collision.gameObject.tag == "Node")
         {
            objective = collision.gameObject.GetComponent<NodeController>().SelectNodeRandom();
            energy -= collision.gameObject.GetComponent<NodeController>().energyCost;
            if (energy <= 0)
            {
                StartCoroutine(Rest()); 
            }
        }
     }
    IEnumerator Rest()
    {
        repos = true;
        yield return new WaitForSeconds(restTime);
        repos = false;
        energy = 10f; 
    }
}
