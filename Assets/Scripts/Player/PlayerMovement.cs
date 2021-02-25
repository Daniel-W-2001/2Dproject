using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 1f;
    public float jumpForce = 1f;

    private Rigidbody2D rb;

    public Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //Player Movement
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed;

        animator.SetFloat("Speed", Mathf.Abs(movement));

        //Player rotation
        if (movement > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (movement < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        //Player Jump
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            animator.SetBool("IsJumping", true);
        }
        if (Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            animator.SetBool("IsJumping", false);
        }
    }
}
