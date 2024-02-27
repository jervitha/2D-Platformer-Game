using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
 [SerializeField] private int maxHealth, currentHealth;
 [SerializeField] private float invisiblityLength = 1f;
  private float invisiblityCounter;
 [SerializeField] private SpriteRenderer theSR;
 [SerializeField] private Color normalcolor, fadecolor;
 private CharcterController thePlayer;

    public static PlayerHealth instance;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        thePlayer = GetComponent<CharcterController>();
        currentHealth = maxHealth;
        UIController.instance.UpdateHealthDisplay(currentHealth, maxHealth);
    }
    public int CurrentHealth
    {
        get { return currentHealth; }
    }
    public int MaxHealth
    {
        get { return maxHealth; }
    }
    private void Update()
    {
        if (invisiblityCounter > 0)
        {
            invisiblityCounter -= Time.deltaTime;

            if (invisiblityCounter <= 0)
            {
                theSR.color = normalcolor;
            }

        }
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.H))
        {
            AddHealth(1);
        }
#endif
    }

    public void DamagePlayer()
    {
        if (invisiblityCounter <= 0)
        {

            currentHealth -= 1;
            if (currentHealth <= 0)
            {
                
                currentHealth = 0;
                LifeController.instance.Respawn();
                
            }
            else

            {
              
                invisiblityCounter = invisiblityLength;
                theSR.color = fadecolor;
                thePlayer.KnockBack();
            }
            UIController.instance.UpdateHealthDisplay(currentHealth, maxHealth);
        }
    }

    public void AddHealth(int amountToAdd)
    {
        currentHealth += amountToAdd;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        UIController.instance.UpdateHealthDisplay(currentHealth, maxHealth);
    }
}