using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblePickup : MonoBehaviour
{
   [SerializeField] private int amount = 1;
   private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<CharcterController>() != null)
        {
            if(CollectiblesManager.instance!=null)
            {
                CollectiblesManager.instance.GetCollelctibles(amount);
                Destroy(gameObject);
                
            }
        }
    }
}
