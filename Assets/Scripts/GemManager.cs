using UnityEngine;

public class GemManager : MonoBehaviour
{

    public static GemManager instance;
    
    public GameObject greenGem;
    public GameObject blueGem;
    public GameObject yellowGem;
    public GameObject purpleGem;
    
    public bool green = false;
    public bool blue = false;
    public bool yellow = false;
    public bool purple = false;
    
    
    private void Awake()
    {
        if (instance == null) instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        DontDestroyOnLoad(this);
    }


    // Update is called once per frame
    void Update()
    {
        
         if (greenGem.activeSelf) {
             green = true;
         }
         if (blueGem.activeSelf) {
             blue = true;
         }
         if (yellowGem.activeSelf) {
             yellow = true;
         }
         if (purpleGem.activeSelf) {
             purple = true;
         }
        
        
    }
}
