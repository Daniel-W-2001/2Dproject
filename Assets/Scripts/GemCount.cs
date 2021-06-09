using UnityEngine;
using UnityEngine.UI;

public class GemCount : MonoBehaviour
{
    Text text; 
    public static int gemCount;


    void Start()
    {
        gemCount = 0;
        text = GetComponent<Text>();
    }

    void Update()
    {
        text.text = gemCount.ToString();
    }
}
