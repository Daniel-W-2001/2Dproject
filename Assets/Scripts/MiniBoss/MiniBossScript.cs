using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBossScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public Animator animator;
    public MiniBossCam radiusScript;

    public int maxHealth = 500;
    public int currentHealth;
    public Canvas canvas;
    public MiniBossHealthBar healthBar;
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

    static int stunCount = 0;
    public PlayerCombat playerCombat;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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

        if (currentHealth <= 0)
        {
            Die();
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
            colInfo.GetComponent<PlayerCombat>()?.TakeDamage(attackDamage);
        }
    }

    public void TakeDamage(int damage)
    {
        StartCoroutine(DamageEffect());
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        stunCount += 1;
        //Play hurt animation
        if (stunCount >= 3)
        {
            animator.SetTrigger("Knockback");
            playerCombat.TakeKnockback();
            stunCount = 0;
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

    public void Deflect()
    {
        animator.SetTrigger("Deflect");
        deflectSound.Play();
        instantiatedObject = Instantiate(fireball, deflectPoint.position, deflectPoint.rotation);
        Destroy(instantiatedObject, 4f);
    }

    void Die()
    {
        canvas.enabled = false;

        //Die animation
        animator.SetBool("IsDead", true);
        //Disable enemy
        miniBossDead = true;
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
