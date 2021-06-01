using UnityEngine;

public class StaticCam : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Camera.main.transform.position = transform.position + new Vector3(0, 0, -10);
        }
    }
}
