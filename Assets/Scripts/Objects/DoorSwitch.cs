using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitch : MonoBehaviour
{
    bool radius;
    public GameObject textPopup;
    MeshRenderer text;
    public GameObject leverOn;
    public GameObject leverOff;
    public GameObject doorOpen;
    public GameObject doorClosed;
    bool open = false;

    public AudioSource leverSound;

    private void Start()
    {
        doorOpen.SetActive(false);
        leverOn.SetActive(false);
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
        if ((radius == true) && Input.GetKeyDown(KeyCode.S) && (open == false))
        {
            leverOn.SetActive(true);
            leverOff.SetActive(false);
            doorOpen.SetActive(true);
            doorClosed.SetActive(false);
            leverSound.Play();
            Invoke("Open", 1);
        }

        if ((radius == true) && Input.GetKeyDown(KeyCode.S) && (open == true))
        {
            leverOn.SetActive(false);
            leverOff.SetActive(true);
            doorOpen.SetActive(false);
            doorClosed.SetActive(true);
            leverSound.Play();
            Invoke("Closed", 1);
        }
    }
    void Open()
    {
        open = true;
    }
    void Closed()
    {
        open = false;
    }
}
