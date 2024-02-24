using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healthToAdd;
    public GameObject pickupEffect;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            if (PlayerHealth.instance.currentHealth != PlayerHealth.instance.maxHealth)
            {
                PlayerHealth.instance.AddHealth(healthToAdd);
                Destroy(gameObject);
                Instantiate(pickupEffect, transform.position, transform.rotation);
            }
        }
    }
}
