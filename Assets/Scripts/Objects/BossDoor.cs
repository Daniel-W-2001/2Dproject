using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDoor : MonoBehaviour
{
    bool radius = false;
    public WitchBoss bossScript;
    public AudioSource doorSound;
    public GameObject player;
    public GameObject doorClosed;
    public GameObject door2;

    void OnTriggerStay2D(Collider2D hitBox)
    {
        if (hitBox.tag == "Player")
        {
            radius = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            radius = false;
        }
    }
    private void Update()
    {
        if ((bossScript.bossDead == true))
        {
            doorClosed.SetActive(false);

            if ((radius == true) && Input.GetKeyDown(KeyCode.S))
            { 
            player.transform.position = door2.transform.position;
            doorSound.Play();
            }
        }
    }
}