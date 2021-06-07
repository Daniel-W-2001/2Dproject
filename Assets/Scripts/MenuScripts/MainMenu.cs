using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    void Start()
    {
        LifeCount.lifeCount = 5;
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Intro");
    }
}
