using UnityEngine;

public class FindGemManager : MonoBehaviour
{
    public static FindGemManager instance;

    public NonSceneDependent gemBooleans;

    public GameObject greenGem;
    public GameObject blueGem;
    public GameObject yellowGem;
    public GameObject purpleGem;
    
    // Start is called before the first frame update
    void Start()
    {
        gemBooleans = FindObjectOfType<NonSceneDependent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gemBooleans.blue) {
            blueGem.SetActive(true);
        }
        
        if (gemBooleans.green) {
            greenGem.SetActive(true);
        }
        
        if (gemBooleans.yellow) {
            yellowGem.SetActive(true);
        }
        
        if (gemBooleans.purple) {
            purpleGem.SetActive(true);
        }
    }
}
