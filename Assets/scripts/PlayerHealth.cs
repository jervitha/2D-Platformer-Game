using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public GameManager gameManager;
    public int maxHealth = 10;
    public int health;
    public SpriteRenderer playersr;
    public NewBehaviourScript playerMovement;
    private bool isDead;
    [SerializeField] private ParticleSystem testparticlesystem = default;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        health -= damage;
        //  ReloadLevel();//AS OF NOW
        if (health <= 0 && !isDead)
        {
            isDead = true;
            playersr.enabled = false;
            playerMovement.enabled = false;
            StartCoroutine(DeathSequence());
        }

    }

    private IEnumerator DeathSequence()
    {
        testparticlesystem.Play();
        yield return new WaitForSeconds(testparticlesystem.main.duration);
        gameManager.gameOver();
            SceneManager.LoadScene(7);
            SoundManager.Instance.PlayMusic(Sounds.PlayerDeath);
          
        }
    
   // private void ReloadLevel()
    //{
      //  SceneManager.LoadScene(0);
   // }
}
