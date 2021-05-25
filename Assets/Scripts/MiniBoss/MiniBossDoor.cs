using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniBossDoor : MonoBehaviour
{
    bool radius = false;
    public MiniBossScript bossScript;
    public AudioSource doorSound;
    public GameObject player;
    public GameObject doorClosed;
    public GameObject door2;
    public GameObject textPopup;
    MeshRenderer text;

    public Button ib;
    public GameObject interactButton;
    public GameObject jumpButton;

    private void Start()
    {
        Button btn = ib.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        text = textPopup.GetComponent<MeshRenderer>();
        text.enabled = false;
    }
    void OnTriggerStay2D(Collider2D hitBox)
    {
        if ((bossScript.miniBossDead == true))
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
        if ((bossScript.miniBossDead == true))
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
        if ((bossScript.miniBossDead == true))
        {
            if (radius == true)
            {
                player.transform.position = door2.transform.position;
                doorSound.Play();
            }
        }
    }
    private void Update()
    {
        if ((bossScript.miniBossDead == true))
        {
            doorClosed.SetActive(false);
        }
    }
}
