using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public static AudioManager Instance { get { return instance; } }
    public SoundType[] sounds;
   [SerializeField]private AudioSource soundEffect;
   [SerializeField]private AudioSource soundMusic;
   [SerializeField]private bool isMute = false;
   [SerializeField]private float volume = 1f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        SetVolume(0.5f);
        PlayMusic(Sounds.Music);
    }
    public void Mute(bool status)
    {
        isMute = status;
    }
    public void SetVolume(float Volume)
    {
        volume = Volume;
        soundEffect.volume = volume;
        soundMusic.volume = volume;
    }
    public void PlayMusic(Sounds sound)
    {
        if (isMute)
            return;

        AudioClip clip = getSoundClip(sound);
        if (clip != null)
        {
            soundMusic.clip = clip;
            soundMusic.Play();
        }
        else
        {
            Debug.Log("clip not found");
        }
    }
    public void Play(Sounds sound)
    {
        AudioClip clip = getSoundClip(sound);
        if(clip!=null)
        {
            soundEffect.PlayOneShot(clip);
        }
        else
        {
            Debug.Log("clip not found");
        }

    }

    private AudioClip getSoundClip(Sounds sound)
    {
        SoundType item = Array.Find(sounds, i=> i.soundType == sound);
        if(item!=null)
            return item.audioClip;
        return null;
        
    }
}

[Serializable]
public class SoundType
{
    public Sounds soundType;
    public AudioClip audioClip;
}
public enum Sounds
{

    ButtonClick,
    Music,
    PlayerMove,
    Playerdeath,
    EnemyDeath
}