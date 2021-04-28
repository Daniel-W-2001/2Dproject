using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    bool radius;
    public GameObject textPopup;
    MeshRenderer text;
    public AudioSource doorSound;
    public GameObject player;
    public GameObject door2;

    public Button ib;
    public GameObject interactButton;
    public GameObject jumpButton;

    private void Start()
    {
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
        if (radius == true)
        {
            player.transform.position = door2.transform.position;
            doorSound.Play();
        }
    }
}
