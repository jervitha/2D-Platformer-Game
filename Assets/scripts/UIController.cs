using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public static UIController instance;
   
    private void Awake()
    {
        instance = this;
    }
    public Image[] heartIcons;
 
  [SerializeField]private Sprite heartFull, heartEmpty;
  [SerializeField]private TMP_Text livesText, collectiblesText;
  [SerializeField] private GameObject gameOverScreen;
  [SerializeField] private GameObject pauseScreen;
  [SerializeField] private string mainMenuScene;
  [SerializeField] private Image fadeScreen;
  [SerializeField] private float fadeSpeed;
  [SerializeField] private bool fadeToBlack;
  [SerializeField] private bool fadeFromBlack;


    private void Start()
    {
        FadeFromBlack();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnpause();
        }
        if(fadeFromBlack)
        {
            fadeScreen.color = new Color(
                fadeScreen.color.r,
                fadeScreen.color.g,
                fadeScreen.color.b,
                Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
        }
        if(fadeToBlack)
        {
            fadeScreen.color = new Color(
              fadeScreen.color.r,
              fadeScreen.color.g,
              fadeScreen.color.b,
              Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
        }
    }
    public void UpdateHealthDisplay(int health,int maxHealth)
    {
        for (int i = 0; i < heartIcons.Length; i++)
        {
            heartIcons[i].enabled = true;

          if(health>i)
            {
                heartIcons[i].sprite = heartFull;
            }
          else
            {
                heartIcons[i].sprite =heartEmpty;
            }
            if (maxHealth <= i)
            {
                heartIcons[i].enabled = false;
            }

        }
    }

  public void UpdateLivesDisplay(int currentLives)
    {
        livesText.text = currentLives.ToString();
    }

    public void ShowGameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void UpdateCollectibles(int amount)
    {
        collectiblesText.text = amount.ToString();
    }

    public void PauseUnpause()
    {
        if(pauseScreen.activeSelf==false)
        {
            pauseScreen.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pauseScreen.SetActive(false);
            Time.timeScale = 1f;
        }

    }
    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenuScene);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void FadeFromBlack()
    {
        fadeFromBlack = true;
        fadeToBlack = false;
    }

    public void FadeToBlack()
    {
        fadeFromBlack = false;
        fadeToBlack = true;
    }
}
