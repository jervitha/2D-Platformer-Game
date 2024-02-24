using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishPoint : MonoBehaviour

{
    private bool isEnding;
    public string nextLevel;
    public float waitToEnd = 2f;
    public GameObject blocker;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (isEnding == false)
        {
            if (collision.tag == "Player")
            {
                isEnding = true;
                blocker.SetActive(true);
                StartCoroutine(EndLevelCo());
            }
        }
    }

    IEnumerator EndLevelCo()
    {
        yield return new WaitForSeconds(waitToEnd);
        SceneManager.LoadScene(nextLevel);

    }

    
}
