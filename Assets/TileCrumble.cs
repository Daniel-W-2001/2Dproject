using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCrumble : MonoBehaviour
{
    public AudioSource crack;
    private void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.collider.CompareTag("Player"))
        {
            StartCoroutine(Breakage());
        }
    }

    IEnumerator Breakage()
    {
        crack.Play();
        yield return new WaitForSeconds(.2f);
        Destroy(gameObject);
    }
}
