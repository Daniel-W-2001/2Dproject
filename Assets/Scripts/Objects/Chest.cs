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


    private void Start()
    {
        chestOpen.SetActive(false);
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
        if ((radius == true) && Input.GetKeyDown(KeyCode.S) && (open == false))
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
