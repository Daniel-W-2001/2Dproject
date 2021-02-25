using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    // Enemy Part
    public EnemyObject scriptEnemy;
    private Animator animator;
    public Transform player2;

    int currentHeatlh;
    
    private bool isFlipped = false;

    // Enemy Attack Part
    private Vector3 attackOffset;
    private float attackRange;
    private LayerMask attackMask;
    private int attackDamage;

    void Start()
    {
        // Enemy part
        animator = GetComponent<Animator>();
        
        currentHeatlh = scriptEnemy.maxHealth;
        
        isFlipped = scriptEnemy.isFlipped;

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