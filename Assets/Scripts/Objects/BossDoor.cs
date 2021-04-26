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

    public Joystick joystick;

    // How long the player needs to stay at location
    public float timerCountDown = .5f;

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
            timerCountDown = .5f;
        }
    }
    private void Update()
    {
        // Collision timer
        if (radius == true)
        {
            timerCountDown -= Time.deltaTime;
            if (timerCountDown < 0)
            {
                timerCountDown = 0;
            }
        }

        if ((bossScript.bossDead == true))
        {
            doorClosed.SetActive(false);

            if (radius == true)
                if (timerCountDown <= 0)
                    if (joystick.Vertical <= -.5f)
                    {
                        player.transform.position = door2.transform.position;
                        doorSound.Play();
                    }
        }   
    }
}