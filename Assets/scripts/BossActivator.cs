using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActivator : MonoBehaviour
{
    public BossbattleController theBoss;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            theBoss.ActivateBattle();
            gameObject.SetActive(false);
        }
    }
}
