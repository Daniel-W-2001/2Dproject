using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Witch : MonoBehaviour
{
    public Transform player;
    public bool isFlipped = false;

    float attackRange = 10f;
    public Animator animator;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    public Transform firePoint;
    public GameObject spell;
    GameObject instantiatedObject;
    //public AudioSource spellSound;

    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public Canvas canvas;

    public GameObject deathEffect;
    public GameObject effectPoint;
    private bool hasPlayed = false;

    private void Start()
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

    void Update()
    {
        if ((Vector2.Distance(transform.position, player.position) <= attackRange) && (Time.time >= nextAttackTime))
        {
            animator.SetTrigger("Attack");
            Shoot();
            nextAttackTime = Time.time + 1f / attackRate;
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            TakeDamage(20);
        }
    }

    void Shoot()
    {
        instantiatedObject = Instantiate(spell, firePoint.position, firePoint.rotation);
        Destroy(instantiatedObject, 2f);
        //spellSound.Play();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        //Play hurt aniamtion
        //animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        canvas.enabled = false;
        Invoke("Disable", 2);

        //Die animation
        animator.SetBool("IsDead", true);
    }

    void Disable()
    {
        if (!hasPlayed)
        {
            var effect = (GameObject)Instantiate(deathEffect, effectPoint.transform.position, Quaternion.identity);
            Destroy(effect, 2);
            hasPlayed = true;
            //GetComponent<Collider2D>().enabled = false;
            this.gameObject.SetActive(false);
        }
    }
}
