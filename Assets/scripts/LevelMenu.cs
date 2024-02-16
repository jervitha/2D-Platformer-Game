using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    public Button[] button;
    public GameObject levelbuttons;
    private void Awake()
    {
       
        int unlockedlevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        for (int i=0;i<button.Length;i++)
        {
            button[i].interactable = false;
            Debug.Log("false");
        }
        for (int i = 0; i <unlockedlevel; i++)
        {
            button[i].interactable = true;
            Debug.Log("true");
           
        }

    }
   

    // Start is called before the first frame update
    public void OpenLevel(int levelid)
    {
        string levelname = "level" + levelid;
        SceneManager.LoadScene(levelname);

    }    //  Debug.Log("Attempting to open level: " + levelid);
        //public void OpenLevel(int levelid)
        //{
          //  string levelname = "level1";
            //SceneManager.LoadScene(levelname);
            //Debug.Log("Attempting to open scene: " + levelname);
        //}




    }


