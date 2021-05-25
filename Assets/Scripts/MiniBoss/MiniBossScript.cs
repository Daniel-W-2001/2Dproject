using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBossScript : MonoBehaviour
{
    public Animator animator;
    public MiniBossCam radiusScript;

    public int maxHealth = 500;
    public int currentHealth;
    public HealthBar healthBar;
    public bool miniBossDead = false;

    public Transform player;
    public bool isFlipped = false;

    public int attackDamage = 35;

    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;

    public Transform deflectPoint;
    GameObject instantiatedObject;
    public GameObject fireball;
    public AudioSource deflectSound;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (radiusScript.miniBossRadius == true)
        {
            animator.SetBool("Radius", true);
        }
        if (radiusScript.miniBossRadius == false)
        {
            animator.SetBool("Radius", false);
        }
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

    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null)
        {
            colInfo.GetComponent<PlayerCombat>().TakeDamage(attackDamage);
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

    public void Deflect()
    {
        animator.SetTrigger("Deflect");
        deflectSound.Play();
        instantiatedObject = Instantiate(fireball, deflectPoint.position, deflectPoint.rotation);
        Destroy(instantiatedObject, 4f);
    }

    void Die()
    {
        Debug.Log("Enemy died!");

        //Die animation
        animator.SetBool("IsDead", true);

        //Disable enemy
        miniBossDead = true;
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
