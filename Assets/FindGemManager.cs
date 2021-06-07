using System.Collections;
using UnityEngine;
public class FindGemManager : MonoBehaviour
{

    public NonSceneDependent gemBooleans;

    public GameObject greenGem;
    public GameObject blueGem;
    public GameObject yellowGem;
    public GameObject purpleGem;
    
    void Awake()
    {
        gemBooleans = GameObject.Find("NonSceneDependent").GetComponent<NonSceneDependent>();
    }

    void Start()
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

        StartCoroutine(DisableGems());
    }

    IEnumerator DisableGems()
    {
        yield return new WaitForSeconds(1f);
        gemBooleans.green = false;
        gemBooleans.blue = false;
        gemBooleans.yellow = false;
        gemBooleans.purple = false;
    }
}
