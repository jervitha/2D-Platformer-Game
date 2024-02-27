using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    public static LifeController instance;
    [SerializeField] private GameObject playerGameObject; 
    private CharcterController thePlayer;
    [SerializeField] private float respawnDelay = 2f;
    [SerializeField] private int currentLives = 3;
    [SerializeField] private GameObject deathEffect;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
       
        thePlayer = playerGameObject?.GetComponent<CharcterController>();

        
        UpdateDisplay();
    }

    public void Respawn()
    {

    
        thePlayer.gameObject.SetActive(false);
        thePlayer.TheRB.velocity = Vector2.zero;
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
        CheckpointManager checkpointManager = thePlayer.GetComponent<CheckpointManager>();

        if (checkpointManager != null)
        {
            thePlayer.transform.position = checkpointManager.RespawnPoint;
        }
      

        PlayerHealth.instance.AddHealth(PlayerHealth.instance.MaxHealth);
        thePlayer.gameObject.SetActive(true);

    }

    public IEnumerator GameOverCo()
    {
        yield return new WaitForSeconds(respawnDelay);
        if (UIController.instance != null)
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
