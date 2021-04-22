using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    public AudioSource StageMusic;

    private void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.CompareTag("Player"))
        {
            StartCoroutine(Music());
        }
    }

    IEnumerator Music()
    {
        yield return new WaitForSeconds(.5f);
        StageMusic.Play();
    }
}
