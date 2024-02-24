using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    public static LifeController instance;
    private CharcterController thePlayer;
    public float respawnDelay = 2f;
    public int currentLives = 3;
    public GameObject deathEffect;

    private void Awake()
    {
        instance = this;
    }
    
    void Start()
    {
        thePlayer = FindFirstObjectByType<CharcterController>();

        UpdateDisplay();
    }

  
    void Update()
    {
        
    }

    public void Respawn()
    {
        thePlayer.gameObject.SetActive(false);
        thePlayer.theRB.velocity=Vector2.zero;
        currentLives--;
        if (currentLives > 0)
        {
            StartCoroutine(RespawnCo());
        }
        else
        {
            currentLives = 0;
            StartCoroutine(GameOverCo());
        }

        UpdateDisplay();
        Instantiate(deathEffect, thePlayer.transform.position, transform.rotation);
    }

    public IEnumerator RespawnCo()
    {
        yield return new WaitForSeconds(respawnDelay);
        thePlayer.transform.position = FindFirstObjectByType<CheckpointManager>().respawnPoint;
        PlayerHealth.instance.AddHealth(PlayerHealth.instance.maxHealth);
        thePlayer.gameObject.SetActive(true);
        
    }

    public IEnumerator GameOverCo()
    {
        yield return new WaitForSeconds(respawnDelay);
        if(UIController.instance!=null)
        {
            UIController.instance.ShowGameOver();
          
        }
    }

    public void AddLife()
    {
        currentLives++;
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        if (UIController.instance != null)
        {
            UIController.instance.UpdateLivesDisplay(currentLives);
        }
    }
}
