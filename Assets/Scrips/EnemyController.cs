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

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        if (followingPlayer && objective != null && !repos && energy > 0)
        {
            transform.position = Vector2.SmoothDamp(transform.position, objective.transform.position, ref speedReference, 0.5f);
        }
        else if (objective == null)
        {
            Debug.LogWarning("El objetivo no está asignado en el EnemyController.");
        }
        else
        {
            // Si no sigue al jugador, regresa al nodo inicial
            transform.position = Vector3.MoveTowards(transform.position, initialPosition, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, initialPosition) < 0.1f)
            {
                transform.position = initialPosition;
            }
        }
    }

    public void StartFollowingPlayer()
    {
        followingPlayer = true;
        initialPosition = transform.position; 
    }

    public void ReturnToInitialNode()
    {
        followingPlayer = false;
        objective = initialNode;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        NodeController nodeController = collision.gameObject.GetComponent<NodeController>();
        if (nodeController != null)
        {
            GameObject nextNode = nodeController.SelectNodeRandom();
            if (nextNode != null)
            {
                objective = nextNode;
                energy -= nodeController.energyCost;
                if (energy <= 0)
                {
                    StartCoroutine(Rest());
                }
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
