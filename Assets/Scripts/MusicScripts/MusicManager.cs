using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource backGroundMusic;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void ChangeMusic(AudioClip music)
    {
        backGroundMusic.Stop();
        backGroundMusic.clip = music;
        backGroundMusic.Play();
    }
}
