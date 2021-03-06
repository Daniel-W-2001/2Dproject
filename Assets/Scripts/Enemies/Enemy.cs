using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Space] 
    public bool usedAfterDeath = false;
    public int destroyTime = 2;
    [Space]
    
    public Animator animator;

    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    public Transform player;
    public bool isFlipped = false;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        //Play hurt aniamtion
        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
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
        if (!usedAfterDeath)
        {
            StartCoroutine(Decay(destroyTime));
        }
    }
    
    IEnumerator Decay(int time)
    {
        yield return new WaitForSeconds(destroyTime);
        Debug.Log(gameObject.name + " was destroyed to save memory");
        Destroy(gameObject);
        // Kan være lurt å slette gameObject hvis det ikke skal brukes igjen
    }
}