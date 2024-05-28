using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyaIm : MonoBehaviour
{
    private EnemyController enemyController;

    private void Start()
    {
        enemyController = GetComponentInParent<EnemyController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemyController.StartFollowingPlayer();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemyController.ReturnToInitialNode();
        }
    }
}
