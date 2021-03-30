using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBallScript : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 40;
    public Rigidbody2D rb;
    public GameObject explosion;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerCombat enemy = hitInfo.GetComponent<PlayerCombat>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            var boom = Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(boom, 1f);
        }
    }
}
