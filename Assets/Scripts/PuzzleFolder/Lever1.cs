using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lever1 : MonoBehaviour
{
    bool radius;
    public GameObject textPopup;
    MeshRenderer text;
    public GameObject leverOn;
    public GameObject leverOff;
    bool open = false;
    public bool lever1 = false;

    public AudioSource leverSound;

    public Button ib;
    public GameObject interactButton;
    public GameObject jumpButton;

    private void Start()
    {
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
            leverSound.Play();
            Invoke("Open", 1);
            lever1 = true;
        }
        if ((radius == true) && (open == true))
        {
            leverOn.SetActive(false);
            leverOff.SetActive(true);
            leverSound.Play();
            Invoke("Closed", 1);
            lever1 = false;
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
