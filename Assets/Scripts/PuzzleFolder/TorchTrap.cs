using UnityEngine;

public class TorchTrap : MonoBehaviour
{
    [Header("TorchObjects")]
    public Torch[] torches;
    
    [Header("What will the torch shoot?")]
    public GameObject fireball;
    
    [SerializeField]private int ignitedCount = 0;
    
    // Update is called once per frame
    void Update()
    {
        if (torches[ignitedCount].ignited)
        {
            ignitedCount++;
            
            if (ignitedCount == torches.Length) {
                Instantiate(fireball, gameObject.transform.position, Quaternion.identity);
                gameObject.SetActive(false);
            }
        }
        
        
    }
    
}
