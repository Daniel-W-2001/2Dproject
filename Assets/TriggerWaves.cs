using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWaves : MonoBehaviour
{
    public GameObject[] enemiesLeft, enemiesRight;
    public GameObject spawnpoint1, spawnpoint2;
    private Collider2D steve;
    private void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.CompareTag("Player"))
        {
            steve = GetComponent<Collider2D>();
            steve.enabled = false;
            
            Debug.Log("The player was detected");
            StartCoroutine(Wave1());
        }
        
        
    }

    private IEnumerator Wave1()
    {
        Debug.Log("Wave 1 is in progress...");
        yield return new WaitForSeconds(10);
        StartCoroutine(Wave2());
    }
    
    IEnumerator Wave2()
    {
        Debug.Log("Wave 2 is in progress...");
        yield return new WaitForSeconds(10);
        StartCoroutine(Wave3());
    }
    
    IEnumerator Wave3()
    {
        this.gameObject.SetActive(false);
        Debug.Log("The Final Wave is in progress...");
        yield return null;
    }
}
