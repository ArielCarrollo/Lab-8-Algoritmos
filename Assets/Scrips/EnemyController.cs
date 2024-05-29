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
    private GameObject initialNode;
    private bool followingPlayer = false;
    private Vector3 initialPosition;
    private float moveSpeed = 2f;
    private GameObject originalObjective;
    private void Update()
    {
        if (!repos && energy > 0 && objective != null)
        {
            transform.position = Vector2.SmoothDamp(transform.position, objective.transform.position, ref speedReference, 0.5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            objective = collision.gameObject;
        }
        else
        {
            NodeController nodeController = collision.gameObject.GetComponent<NodeController>();
            if (nodeController != null)
            {
                objective = nodeController.SelectNodeRandom().gameObject;
                energy -= nodeController.energyCost;
                if (energy <= 0)
                {
                    StartCoroutine(Rest());
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            followingPlayer = false;
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
