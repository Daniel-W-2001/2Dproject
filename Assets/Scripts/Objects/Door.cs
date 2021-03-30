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
        if(other.tag == "Player")
        {
            radius = false;
            text.enabled = false;
        }
    }
    private void Update()
    {
        if ((radius == true) && Input.GetKeyDown(KeyCode.S))
        {
            player.transform.position = door2.transform.position;
            doorSound.Play();
        }
    }
}
