using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireball : MonoBehaviour
{
    public Animator animator;

    public Transform firePoint;
    public GameObject fireball;
    GameObject instantiatedObject;
    public AudioSource fireballSound;

    private bool cooldown = false;
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                animator.SetBool("IsJumping", false);
                animator.SetTrigger("CastFireball");
                Shoot();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }   
    }

    public void Shoot()
    {
        if (cooldown == false)
        {
            animator.SetBool("IsJumping", false);
            animator.SetTrigger("CastFireball");
            instantiatedObject = Instantiate(fireball, firePoint.position, firePoint.rotation);
            Destroy(instantiatedObject, 2f);
            fireballSound.Play();
            //Cooldown for buttonpress
            Invoke("ResetCooldown", .5f);
            cooldown = true;
        }
    }

    void ResetCooldown()
    {
        cooldown = false;
    }
}
