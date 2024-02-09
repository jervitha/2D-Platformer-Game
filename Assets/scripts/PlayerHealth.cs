using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        health = health - damage;
        ReloadLevel();//AS OF NOW
        if (health<=0)
        {
            ReloadLevel();
        }
    }
    private void ReloadLevel()
    {
        SceneManager.LoadScene(0);
    }
}
