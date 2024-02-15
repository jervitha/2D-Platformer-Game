using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioListener : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] AudioSource musicSource;

    [SerializeField] AudioSource SFXSource;

    public AudioClip background;

    public AudioClip death;
    public AudioClip wallTouch;
    public AudioClip PortalIn;
    public AudioClip PortalOut;
    public AudioClip Checkpoint;


    private void start()
    {
        musicSource.clip = background;
        musicSource.Play();

    }


}