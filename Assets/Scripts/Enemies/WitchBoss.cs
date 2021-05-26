using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchBoss : MonoBehaviour
{
    public Transform player;
    public bool isFlipped = false;
    public bool bossDead = false;

    float attackRange = 20f;
    float finalAttackRange = 11f;
    public Animator animator;

    float stage2AttackRate = 0.3f;
    public float attackRate = 0.8f;
    float nextAttackTime = 0f;

    public Transform firePoint;
    public GameObject spell;
    public GameObject powerSpell;
    GameObject instantiatedObject;
    //public AudioSource spellSound;

    public int maxHealth = 500;
    public int currentHealth;
    public HealthBar healthBar;
    public Canvas canvas;

    public GameObject deathEffect;
    public GameObject effectPoint;
    private bool hasPlayed = false;

    public GameObject point1;
    public GameObject point2;
    public GameObject point3;
    bool point1done = false;
    bool point2done = false;
    bool point3done = false;

    public GameObject potion;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void BossLookAtPlayer()
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
        if ((Vector2.Distance(transform.position, player.position) <= attackRange) && (Time.time >= nextAttackTime) && (currentHealth > 200))
        {
            animator.SetTrigger("Attack");
            Shoot();
            nextAttackTime = Time.time + 1f / attackRate;
        }

        if (currentHealth <= 400 && (point1done == false))
        {
            point1done = true;
            instantiatedObject = Instantiate(potion, transform.position, Quaternion.identity);
            var effect = (GameObject)Instantiate(deathEffect, effectPoint.transform.position, Quaternion.identity);
            Destroy(effect, 2);
            transform.position = point1.transform.position;
        }

        if (currentHealth <= 300 && (point2done == false))
        {
            point2done = true;
            instantiatedObject = Instantiate(potion, transform.position, Quaternion.identity);
            var effect = (GameObject)Instantiate(deathEffect, effectPoint.transform.position, Quaternion.identity);
            Destroy(effect, 2);
            transform.position = point2.transform.position;
        }

        if (currentHealth <= 200 && (point3done == false))
        {
            point3done = true;
            instantiatedObject = Instantiate(potion, transform.position, Quaternion.identity);
            var effect = (GameObject)Instantiate(deathEffect, effectPoint.transform.position, Quaternion.identity);
            Destroy(effect, 2);
            transform.position = point3.transform.position;
        }

        if ((Vector2.Distance(transform.position, player.position) <= finalAttackRange) && (Time.time >= nextAttackTime) && (currentHealth > 0) && (point3done == true))
        {
            animator.SetTrigger("Attack");
            PowerShoot();
            nextAttackTime = Time.time + 1f / stage2AttackRate;
        }
    }

    void Shoot()
    {
        instantiatedObject = Instantiate(spell, firePoint.position, firePoint.rotation);
        Destroy(instantiatedObject, 4f);
        //spellSound.Play();
    }

    void PowerShoot()
    {
        instantiatedObject = Instantiate(powerSpell, firePoint.position, firePoint.rotation);
        Destroy(instantiatedObject, 10f);
        //spellSound.Play();
    }
    public void TakeDamage(int damage)
    {
        StartCoroutine(DamageEffect());
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        //Play hurt animation
        //animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
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
            bossDead = true;
            hasPlayed = true;
            //GetComponent<Collider2D>().enabled = false;
            this.gameObject.SetActive(false);
        }
    }
}
