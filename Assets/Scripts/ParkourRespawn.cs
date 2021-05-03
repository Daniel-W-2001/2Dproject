using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkourRespawn : MonoBehaviour
{
    public Animator animator;

    public GameObject respawnPoint;

    private void OnTriggerEnter2D(Collider2D player)   
    {


        if (player.CompareTag("Pit"))
        {
            animator.SetBool("IsDead", true);
            Invoke("Die", 1);
        }
    }
    void Die()
    {
        animator.SetBool("IsDead", false);

        transform.position = respawnPoint.transform.position;
    }
}
