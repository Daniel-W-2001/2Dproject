using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchTrap : MonoBehaviour
{
    public Torch torchScript;
    public Torch torchScript2;

    public GameObject fireballs;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (torchScript.ignited && torchScript2.ignited)
        {
            Instantiate(fireballs, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    
}
