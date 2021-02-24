using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    bool radius;
    public GameObject textPopup;
    MeshRenderer text;
    //public AudioSource doorSound;
    public GameObject player;
    public GameObject door2;


    private void Start()
    {
        text = textPopup.GetComponent<MeshRenderer>();
        text.enabled = false;
    }
    void OnTriggerStay2D(Collider2D hitBox)
    {
        Rigidbody2D rb = hitBox.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            radius = true;
            text.enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            radius = false;
            text.enabled = false;
        }
    }
    private void Update()
    {
        if ((radius == true) && Input.GetKeyDown(KeyCode.W))
        {
            player.transform.position = door2.transform.position;
            //doorSound.Play();
        }
    }
}
