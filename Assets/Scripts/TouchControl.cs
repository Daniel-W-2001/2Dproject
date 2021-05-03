using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControl : MonoBehaviour
{
    public float jumpForce = 1f;
    public AudioSource jumpSound;
    public Animator animator;
    public float movementSpeed = 1f;
    private Rigidbody2D rb;

    public void Left()
    {

    }
    public void Right()
    {

    }
    public void Attack()
    {

    }
    public void Jump()
    {
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        jumpSound.Play();
        animator.SetBool("IsJumping", true);
    }
}
