using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{

    private PlayerHealth healthController;
    private void Start()
    {
        healthController = FindFirstObjectByType<PlayerHealth>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerHealth.instance.DamagePlayer();
        }
    }

}
