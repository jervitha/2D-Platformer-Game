using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameOverScreen : MonoBehaviour
{
    public void Setup()
    {
        AudioManager.Instance.PlayMusic(Sounds.Playerdeath);
        gameObject.SetActive(true);

    }
}
