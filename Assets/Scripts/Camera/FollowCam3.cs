using Cinemachine;
using UnityEngine;

public class FollowCam3 : MonoBehaviour
{
    public CinemachineVirtualCamera cam3;

    private void Start()
    {
        cam3.enabled = false;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            cam3.transform.position = transform.position + new Vector3(0, 0, -10);
            cam3.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            cam3.enabled = false;
        }
    }

}
