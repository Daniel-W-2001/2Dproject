using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemCount : MonoBehaviour
{
    Text text; 
    public static int gemCount;


    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        text.text = gemCount.ToString();
    }
}
