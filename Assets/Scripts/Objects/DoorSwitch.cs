using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public Button ib;
    public GameObject interactButton;
    public GameObject jumpButton;

    private void Start()
    {
        doorOpen.SetActive(false);
        leverOn.SetActive(false);
        text = textPopup.GetComponent<MeshRenderer>();
        text.enabled = false;
        Button btn = ib.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
    void OnTriggerStay2D(Collider2D hitBox)
    {
        if (hitBox.tag == "Player")
        {
            interactButton.SetActive(true);
            jumpButton.SetActive(false);
            radius = true;
            text.enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            interactButton.SetActive(false);
            jumpButton.SetActive(true);
            radius = false;
            text.enabled = false;
        }
    }

    public void TaskOnClick()
    {
        if ((radius == true) && (open == false))
        {
            leverOn.SetActive(true);
            leverOff.SetActive(false);
            doorOpen.SetActive(true);
            doorClosed.SetActive(false);
            leverSound.Play();
            Invoke("Open", 1);
        }
        if ((radius == true) && (open == true))
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
