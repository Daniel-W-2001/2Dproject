using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Enemy2 : MonoBehaviour
{
    // Enemy Part
    public EnemyObject scriptEnemy;
    private Animator animator;
    private AnimatorController animController;
    public Transform player2;

    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public Canvas canvas;

    private bool isFlipped = false;

    // Enemy Attack Part
    private Vector3 attackOffset;
    private float attackRange;
    private LayerMask attackMask;
    private int attackDamage;
    
    // EnemyLooks
    public Sprite[] bodyParts;
    
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        SetEnemy();
        SetAttack();
        //SetSprites();
    }

    //WIP
    //void SetSprites() 
    //{
    //    bodyParts = FindObjectOfType<EnemyObject>().sprites;
    //    
    //
    //    for (int i = 0; i < bodyParts.Length; i++)
    //    {
    //        
    //    }
    //}
    void SetEnemy()
    {
        // Enemy part
        animController = scriptEnemy.animController;
        GetComponent<Animator>().runtimeAnimatorController = animController;
        animator = GetComponent<Animator>();
        
        currentHealth = scriptEnemy.maxHealth;
        
        isFlipped = scriptEnemy.isFlipped;
    }
    void SetAttack()
    {
        // Enemy Attack
        attackRange = scriptEnemy.attackRange;
        attackDamage = scriptEnemy.attackDamage;
        attackOffset = scriptEnemy.attackOffset;
        attackMask = scriptEnemy.attackMask;
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

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player2.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player2.position.x && !isFlipped)
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
        canvas.enabled = false;

        //Die animation
        animator.SetBool("IsDead", true);

        //Disable enemy
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
    
    
}