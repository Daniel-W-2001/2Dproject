using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicPowerScript : MonoBehaviour
{
    GameObject player;
    float speed = 5f;
    float RotateSpeed = 40f;
    public int damage = 40;
    public Rigidbody2D rb;
    public GameObject explosion;

    void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = transform.right * speed;

        Vector3 targetVector = player.transform.position - transform.position;

        float rotatingIndex = Vector3.Cross(targetVector, transform.right).z;

        rb.angularVelocity = -1 * rotatingIndex * RotateSpeed;
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
