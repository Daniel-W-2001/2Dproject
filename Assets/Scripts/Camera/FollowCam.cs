using Cinemachine;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public CinemachineVirtualCamera cam;

    private void Start()
    {
        cam.enabled = false;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            cam.transform.position = transform.position + new Vector3(0, 0, -10);
            cam.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            cam.enabled = false;
        }
    }

}
