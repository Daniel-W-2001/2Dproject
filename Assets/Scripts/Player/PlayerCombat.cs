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

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public GameObject potionPickup;
    public AudioSource healSound;

    public AudioSource swordSwing;
    public GameObject respawnPoint;

    private bool grounded = true;
    private bool cooldown = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.001f)
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }

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
            }
        }
    }

    void ResetCooldown()
    {
        cooldown = false;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public void Potion()
    {
        var heal = Instantiate(potionPickup, transform.position, transform.rotation);
        healSound.Play();
        Destroy(heal, 2f);
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
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
