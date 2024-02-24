using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMusic : MonoBehaviour
{
    public int trackToPlay;

    private void Start()
    {
       if(AudioManager.instance!=null)
        {
            AudioManager.instance.PlayLevelMusic(trackToPlay);
        }
    }

}
