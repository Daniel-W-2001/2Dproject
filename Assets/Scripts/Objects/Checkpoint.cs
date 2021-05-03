using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject respawnPoint;

    void OnTriggerEnter2D(Collider2D hitBox)
    {
        if (hitBox.tag == "Player")
        {
            respawnPoint.transform.position = transform.position;
        }
    }
}
