using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    public GameObject explosion;

    public void Explode()
    {
        var boom = Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(boom, 2f);
    }
}
