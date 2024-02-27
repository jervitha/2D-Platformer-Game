using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] private int healthToAdd;
    [SerializeField]  private GameObject pickupEffect;

   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<CharcterController>() != null)
        {
            if (PlayerHealth.instance.CurrentHealth != PlayerHealth.instance.MaxHealth)
            {
                PlayerHealth.instance.AddHealth(healthToAdd);
                Destroy(gameObject);
                Instantiate(pickupEffect, transform.position, transform.rotation);
            }
        }
    }
}
