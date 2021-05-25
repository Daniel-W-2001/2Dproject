using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBossCam : MonoBehaviour
{
    public bool miniBossRadius = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Camera.main.transform.position = transform.position + new Vector3(0, 0, -10);
            miniBossRadius = true;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            miniBossRadius = false;
        }
    }
}
