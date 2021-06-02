using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Witch : MonoBehaviour
{
    public Transform player;
    public bool isFlipped = false;

    public float attackRange = 10f;
    public Animator animator;

    public float attackRate = 0.8f;
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
    
    public bool usedAfterDeath = false;

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
        if ((Vector2.Distance(transform.position, player.position) <= attackRange) && (Time.time >= nextAttackTime) && (currentHealth > 0))
        {
            animator.SetTrigger("Attack");
            Shoot();
            nextAttackTime = Time.time + 1f / attackRate;
        }
    }

    void Shoot()
    {
        instantiatedObject = Instantiate(spell, firePoint.position, firePoint.rotation);
        Destroy(instantiatedObject, 4f);
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
            hasPlayed = true;
            //GetComponent<Collider2D>().enabled = false;
            this.gameObject.SetActive(false);
            if (!usedAfterDeath)
            {
                Debug.Log(gameObject.name + " was destroyed to save memory");
                Destroy(gameObject);
                // Kan være lurt å slette gameObject hvis det ikke skal brukes igjen
            }
            
        }
    }
    

}
