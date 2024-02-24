using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
   
   private void OnCollisionEnter2D(Collision2D other)
    {
       if(other.gameObject.CompareTag("Player"))
        {
           
               PlayerHealth.instance.DamagePlayer();
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Destroy(gameObject);
            FindFirstObjectByType<CharcterController>().Jump();
           
        }
    }
}
