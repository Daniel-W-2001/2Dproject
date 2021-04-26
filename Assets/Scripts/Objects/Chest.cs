using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    bool radius;
    public GameObject textPopup;
    MeshRenderer text;
    public GameObject chestOpen;
    public GameObject chestClosed;
    bool open = false;
    public Collider2D col;
    public GameObject chestEffect;
    public GameObject effectPoint;
    private bool hasPlayed = false;

    public AudioSource chestSound;

    public Joystick joystick;


    private void Start()
    {
        chestOpen.SetActive(false);
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
        }
    }
    private void Update()
    {
        if ((radius == true) && (open == false))
            if (joystick.Vertical <= -.5f)
            {
                chestOpen.SetActive(true);
                chestClosed.SetActive(false);
                chestSound.Play();
                GemCount.gemCount += 1;
                open = true;
                col.enabled = false;
                if (!hasPlayed)
                {
                    var effect = (GameObject)Instantiate(chestEffect, effectPoint.transform.position, Quaternion.identity);
                    Destroy(effect, 1);
                    hasPlayed = true;
                }
            }
    }
}
