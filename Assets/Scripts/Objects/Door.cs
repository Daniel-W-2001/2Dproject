using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    bool radius;
    public GameObject textPopup;
    MeshRenderer text;
    public AudioSource doorSound;
    public GameObject player;
    public GameObject door2;

    public bool doorCooldown = false;
    public Joystick joystick;

    // How long the player needs to stay at location
    public float timerCountDown = .5f;

    private void Start()
    {
        text = textPopup.GetComponent<MeshRenderer>();
        text.enabled = false;
    }
    void OnTriggerStay2D(Collider2D hitBox)
    {
        if (hitBox.tag == "Player")
        {
            radius = true;
            text.enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            radius = false;
            text.enabled = false;
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

        if (radius == true)
            if (timerCountDown <= 0)
                if (joystick.Vertical <= -.5f)
                {
                    player.transform.position = door2.transform.position;
                    doorSound.Play();
                }
    }
}
