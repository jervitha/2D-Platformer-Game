using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
           
            SetupAudioManager();
        }
        else 
        {
            Destroy(gameObject);
        }
    }
                                
   
    public AudioSource menuMusic, bossMusic, levelVictoryMusic;
    public AudioSource[] levelTracks;                                   

    public void SetupAudioManager()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }


    public void StopMusic()
    {
        menuMusic.Stop();
        bossMusic.Stop();
        levelVictoryMusic.Stop();


        foreach(AudioSource track in levelTracks)
        {
            track.Stop();
        }
    }
    public void PlayMenuMusic()
    {
        StopMusic();
        menuMusic.Play();
    }
    public void BossMusic()
    {
        StopMusic();
        bossMusic.Play();
    }
    public void LevelcompleteMusic()
    {
        StopMusic();
        levelVictoryMusic.Play();
    }

    public void PlayLevelMusic(int trackToPlay)
    {
        StopMusic();
        levelTracks[trackToPlay].Play();
    }
    
}
