using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossDoor : MonoBehaviour
{
    bool radius = false;
    public WitchBoss bossScript;
    public AudioSource doorSound;
    public GameObject player;
    public GameObject doorClosed;
    public GameObject door2;

    public Button ib;
    public GameObject interactButton;
    public GameObject jumpButton;

    private void Start()
    {
        Button btn = ib.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
    void OnTriggerStay2D(Collider2D hitBox)
    {
        if ((bossScript.bossDead == true))
        {
            if (hitBox.tag == "Player")
            {
                interactButton.SetActive(true);
                jumpButton.SetActive(false);
                radius = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if ((bossScript.bossDead == true))
        {
            if (other.tag == "Player")
            {
                interactButton.SetActive(false);
                jumpButton.SetActive(true);
                radius = false;
            }
        }
    }

    void TaskOnClick()
    {
        if ((bossScript.bossDead == true))
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
        if ((bossScript.bossDead == true))
        {
            doorClosed.SetActive(false);
        }   
    }
}