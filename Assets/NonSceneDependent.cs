using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonSceneDependent : MonoBehaviour
{
    public static NonSceneDependent instance;

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
}
