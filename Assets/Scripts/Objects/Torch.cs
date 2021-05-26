using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    public GameObject torchOn;
    public GameObject torchOff;
    public bool ignited = false;

    public GameObject explosion;

    private void Start()
    {
        torchOn.SetActive(false);
    }
    public void Ignite()
    {
        if (ignited == false)
        {
            var boom = Instantiate(explosion, transform.position, transform.rotation);
            Destroy(boom, 0.5f);
            torchOn.SetActive(true);
            torchOff.SetActive(false);
            ignited = true;
        }
    }
}
