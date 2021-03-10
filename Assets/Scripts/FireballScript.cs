using System.Collections;
using System.Collections.Generic;
using ScriptableObjects.ScriptableEnemy.Scripts;
using UnityEngine;

public class FireballScript : MonoBehaviour
{
    public float speed = 13f;
    public int damage = 40;
    public Rigidbody2D rb;
    public GameObject explosion;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy2 enemy = hitInfo.GetComponent<Enemy2>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            var boom = Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(boom, 0.5f);
        }

        Barrel barrel = hitInfo.GetComponent<Barrel>();
        if (barrel != null)
        {
            barrel.Explode();
            Destroy(gameObject);
        }
    }
}
