using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D col)
    {
        PlayerCombat player = col.GetComponent<PlayerCombat>();
        if (player != null)
        {
            player.Potion();
            Destroy(gameObject);
        }
    }
}
