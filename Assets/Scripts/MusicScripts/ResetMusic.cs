using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetMusic : MonoBehaviour
{
    public AudioClip newTrack;
    private MusicManager musicManager;

    // Start is called before the first frame update
    void Start()
    {
        musicManager = FindObjectOfType<MusicManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (newTrack != null)
            {
                musicManager.ChangeMusic(newTrack);
            }
        }
    }
}
