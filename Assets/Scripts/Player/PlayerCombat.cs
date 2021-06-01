using System.Collections;
using System.Collections.Generic;
using ScriptableObjects.ScriptableEnemy.Scripts;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;

    private Rigidbody2D rb;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public int attackDamage = 50;

    public int maxHealth = 100;
    public int currentHealth;
    public PlayerHealthbar healthBar;
    public GameObject potionPickup;
    public AudioSource healSound;

    public AudioSource swordSwing;
    public GameObject respawnPoint;

    public GameObject collectEffect;
    public AudioSource collectSound;

    private bool grounded = true;
    private bool cooldown = false;
    public bool stunned = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            animator.SetBool("IsDead", true);
            Invoke("Die", 1);
        }

        if (Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }

    public void Attack()
    {
        if (cooldown == false && grounded == true)
        {
            //Play attack animation
            animator.SetTrigger("Attack");
            swordSwing.Play();
            Invoke("ResetCooldown", .5f);
            cooldown = true;

            //Detect enemies in range
            Collider2D [] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

            //Deal damage to enemies
            foreach(Collider2D enemy in hitEnemies)
            {
            enemy.GetComponent<Enemy2>()?.TakeDamage(attackDamage);
            enemy.GetComponent<Witch>()?.TakeDamage(attackDamage);
            enemy.GetComponent<WitchBoss>()?.TakeDamage(attackDamage);
            enemy.GetComponent<MiniBossScript>()?.TakeDamage(attackDamage);
            }
        }
    }

    void ResetCooldown()
    {
        cooldown = false;
    }

    public void TakeDamage(int damage)
    {
        StartCoroutine(DamageEffect());
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
    public void TakeKnockback()
    {
        stunned = true;
        animator.ResetTrigger("Attack");
        animator.SetTrigger("Knockback");
        Invoke("ResetKnockback", 1f);

        rb.AddForce(new Vector2(0, 10f), ForceMode2D.Impulse);

        if (transform.rotation == Quaternion.Euler(0, 0, 0))
        {
            rb.AddForce(new Vector2(transform.position.x * 5f, 0));
        }
        else if (transform.rotation == Quaternion.Euler(0, -180, 0))
        {
            rb.AddForce(new Vector2(transform.position.x * -5f, 0));
        }
    }

    void ResetKnockback()
    {
        animator.ResetTrigger("Knockback");
        stunned = false;
    }
    IEnumerator DamageEffect()
    {
        SetAllSpriteColours(Color.red);
        yield return new WaitForSeconds(.2f);
        SetAllSpriteColours(Color.white);
    }

    void SetAllSpriteColours(Color col)
    {
        foreach (var sr in GetComponentsInChildren<SpriteRenderer>())
        {
            sr.color = col;
        }
    }

    public void Potion()
    {
        var heal = Instantiate(potionPickup, transform.position, transform.rotation);
        healSound.Play();
        Destroy(heal, 2f);
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    public void GemCollectible()
    {
        var heal = Instantiate(collectEffect, transform.position, transform.rotation);
        collectSound.Play();
        Destroy(heal, 3f);
    }
    void Die()
    {
        animator.SetBool("IsDead", false);
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        transform.position = respawnPoint.transform.position;
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
