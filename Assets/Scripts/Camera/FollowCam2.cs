using Cinemachine;
using UnityEngine;

public class FollowCam2 : MonoBehaviour
{
    public CinemachineVirtualCamera cam2;

    private void Start()
    {
        cam2.enabled = false;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            cam2.transform.position = transform.position + new Vector3(0, 0, -10);
            cam2.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            cam2.enabled = false;
        }
    }

}
