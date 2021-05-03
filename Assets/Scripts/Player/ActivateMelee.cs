using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateMelee : MonoBehaviour
{

    public GameObject meleeButton;
    public GameObject fireballButton;
    public Collider2D col;

    void OnTriggerStay2D(Collider2D hitBox)
    {
        if (hitBox.tag == "Enemy")
        {
            meleeButton.SetActive(true);
            fireballButton.SetActive(false);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            meleeButton.SetActive(false);
            fireballButton.SetActive(true);
        }
    }
}
