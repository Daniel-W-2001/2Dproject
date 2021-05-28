using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleDoor : MonoBehaviour
{
    bool radius = false;
    public GameObject player;
    public GameObject door2;
    public AudioSource doorSound;
    public GameObject doorOpen;
    public GameObject doorClosed;
    public GameObject textPopup;
    MeshRenderer text;

    public Torch torchScript;
    public Lever1 lever1Script;
    public Lever2 lever2Script;
    public Lever3 lever3Script;

    public Button ib;
    public GameObject interactButton;
    public GameObject jumpButton;

    void Start()
    {
        Button btn = ib.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        text = textPopup.GetComponent<MeshRenderer>();
        text.enabled = false;
    }
    void Update()
    {
        if (lever1Script.lever1 == true && lever2Script.lever2 == true && lever3Script.lever3 == true && torchScript.ignited == true)
        {
            doorOpen.SetActive(true);
            doorClosed.SetActive(false);
        }
        else
        {
            doorOpen.SetActive(false);
            doorClosed.SetActive(true);
        }
    }

    void OnTriggerStay2D(Collider2D hitBox)
    {
        if (lever1Script.lever1 == true && lever2Script.lever2 == true && lever3Script.lever3 == true && torchScript.ignited == true)
            {
            if (hitBox.tag == "Player")
            {
                interactButton.SetActive(true);
                jumpButton.SetActive(false);
                radius = true;
                text.enabled = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (lever1Script.lever1 == true && lever2Script.lever2 == true && lever3Script.lever3 == true && torchScript.ignited == true)
        {
            if (other.tag == "Player")
            {
                interactButton.SetActive(false);
                jumpButton.SetActive(true);
                radius = false;
                text.enabled = false;
            }
        }
    }
    void TaskOnClick()
    {
        if (lever1Script.lever1 == true && lever2Script.lever2 == true && lever3Script.lever3 == true && torchScript.ignited == true)
        {
            if (radius == true)
            {
                player.transform.position = door2.transform.position;
                doorSound.Play();
            }
        }
    }
}
