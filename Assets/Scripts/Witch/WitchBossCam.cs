using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchBossCam : MonoBehaviour
{
    public bool bossRadius = false;

    public AudioClip newTrack;
    private MusicManager musicManager;

    void Start()
    {
        musicManager = FindObjectOfType<MusicManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Camera.main.transform.position = transform.position + new Vector3(0, 0, -10);
            bossRadius = true;

            if (newTrack != null)
            {
                musicManager.ChangeMusic(newTrack);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            bossRadius = false;
        }
    }
}
