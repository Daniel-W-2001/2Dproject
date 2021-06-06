using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindGemManager : MonoBehaviour
{
    public static FindGemManager instance;

    public GemManager GemManager;

    public GameObject greenGem;
    public GameObject blueGem;
    public GameObject yellowGem;
    public GameObject purpleGem;
    
    private void Awake()
    {
        if (instance == null) instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        GemManager = FindObjectOfType<GemManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GemManager.blue) {
            blueGem.SetActive(true);
        }
        
        if (GemManager.green) {
            greenGem.SetActive(true);
        }
        
        if (GemManager.yellow) {
            yellowGem.SetActive(true);
        }
        
        if (GemManager.purple) {
            purpleGem.SetActive(true);
        }
    }
}
