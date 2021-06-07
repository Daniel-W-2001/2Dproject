using UnityEngine;
using UnityEngine.UI;

public class LifeCount : MonoBehaviour
{
    Text text;
    public static int lifeCount = 5;


    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        text.text = lifeCount.ToString();
    }
}
