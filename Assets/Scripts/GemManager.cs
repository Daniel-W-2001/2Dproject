using UnityEngine;

public class GemManager : MonoBehaviour
{
    
    public NonSceneDependent NonSceneDependentObject;

    
    public GameObject greenGem;
    public GameObject blueGem;
    public GameObject yellowGem;
    public GameObject purpleGem;



    // Update is called once per frame
    void FixedUpdate()
    {
        
         if (greenGem.activeSelf) {
             NonSceneDependentObject.green = true;
         }
         if (blueGem.activeSelf) {
             NonSceneDependentObject.blue = true;
         }
         if (yellowGem.activeSelf) {
             NonSceneDependentObject.yellow = true;
         }
         if (purpleGem.activeSelf) {
             NonSceneDependentObject.purple = true;
         }
        
        
    }

    
}
