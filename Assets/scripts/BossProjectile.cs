using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour
{
   [SerializeField] private float speed = 8f;
    private Vector3 direction;
   [SerializeField]  private float lifeTime = 3f;


    void Start()
    {
        direction = (PlayerHealth.instance.transform.position - transform.position).normalized;
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.position += direction * (Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
    
        if (other.gameObject.GetComponent<CharcterController>() != null)
        {
            PlayerHealth.instance.DamagePlayer();
            Destroy(gameObject);
        }
    }
}
