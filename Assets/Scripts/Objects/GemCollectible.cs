using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GemCollectible : MonoBehaviour
{
    public float amplitude = 0.15f;
    public float frequency = 1f;

    public GameObject gem;

    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    void Start()
    {
        // Store the starting position & rotation of the object
        posOffset = transform.position;
    }

    void Update()
    {
        // Float up/down with a Sin()
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        PlayerCombat player = col.GetComponent<PlayerCombat>();
        if (player != null)
        {
            player.GemCollectible();
            gem.SetActive(true);
            Destroy(gameObject);
        }
    }
}
