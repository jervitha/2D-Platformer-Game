using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private CharcterController playerController;

    private void OnCollisionEnter2D(Collision2D other)
    {
        CharcterController otherController = other.gameObject.GetComponent<CharcterController>();

        if (otherController != null)
        {
            PlayerHealth.instance.DamagePlayer();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        CharcterController otherController = other.gameObject.GetComponent<CharcterController>();

        if (otherController != null)
        {
            Destroy(gameObject);
            playerController.Jump();
        }
    }
}
