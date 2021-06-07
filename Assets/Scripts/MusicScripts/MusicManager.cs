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
        if (backGroundMusic.clip.name == music.name)
            return;

        backGroundMusic.Stop();
        backGroundMusic.clip = music;
        backGroundMusic.Play();
    }
}
