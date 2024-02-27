using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishPoint : MonoBehaviour

{
    private bool isEnding;
   [SerializeField]private string nextLevel;
   [SerializeField] private float waitToEnd = 2f;
   [SerializeField] private GameObject blocker;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (isEnding == false)
        {
          if (other.gameObject.GetComponent<CharcterController>() != null)
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
