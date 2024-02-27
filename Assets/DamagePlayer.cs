using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    [SerializeField] private PlayerHealth healthController;

    private void OnTriggerEnter2D(Collider2D other)
    {
        CharcterController playerController = other.gameObject.GetComponent<CharcterController>();

        if (playerController != null && healthController != null)
        {
            healthController.DamagePlayer();

        }
    }
}
