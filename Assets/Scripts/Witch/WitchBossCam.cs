using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchBossCam : MonoBehaviour
{
    public AudioClip newTrack;
    private MusicManager musicManager;
    bool bossMusic = false;

    void Start()
    {
        musicManager = FindObjectOfType<MusicManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Camera.main.transform.position = transform.position + new Vector3(0, 0, -10);

            if (newTrack != null && bossMusic == false)
            {
                musicManager.ChangeMusic(newTrack);
                bossMusic = true;
            }
        }
    }
}
