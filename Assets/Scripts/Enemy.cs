using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;

    public int maxHealth = 100;
    int currentHeatlh;


    void Start()
    {
        currentHeatlh = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHeatlh -= damage;

        //Play hurt aniamtion
        animator.SetTrigger("Hurt");

        if (currentHeatlh <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died!");

        //Die animation
        animator.SetBool("IsDead", true);

        //Disable enemy
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}