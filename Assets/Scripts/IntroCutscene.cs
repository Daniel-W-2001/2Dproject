using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroCutscene : MonoBehaviour
{
    float timeLeft = 22f;
    public GameObject blackOutSquare;

    public AudioSource audioSource;
    float duration = 2f;
    float targetVolume = 0f;

    private void Start()
    {
        StartCoroutine(FadeBlackOutSquare(false));
    }
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            StartCoroutine(FadeBlackOutSquare());
            StartCoroutine(FadeAudioSource.StartFade(audioSource, duration, targetVolume));
            Invoke("LoadScene", 2);
        }
    }

    public void Skip()
    {
        StartCoroutine(FadeBlackOutSquare());
        StartCoroutine(FadeAudioSource.StartFade(audioSource, duration, targetVolume));
        Invoke("LoadScene", 2);
    }
    void LoadScene()
    {
            SceneManager.LoadScene("Game");
    }

    public IEnumerator FadeBlackOutSquare(bool fadeToBlack = true, int fadeSpeed = 1)
    {
        Color objectColor = blackOutSquare.GetComponent<Image>().color;
        float fadeAmount;

        if (fadeToBlack)
        {
            while (blackOutSquare.GetComponent<Image>().color.a < 1)
            {
                fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackOutSquare.GetComponent<Image>().color = objectColor;
                yield return null;
            }
        }
        else
        {
            while (blackOutSquare.GetComponent<Image>().color.a > 0)
            {
                fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackOutSquare.GetComponent<Image>().color = objectColor;
                yield return null;
            }
        }
    }
}
