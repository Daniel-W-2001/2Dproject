using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGameDoor : MonoBehaviour
{
    bool radius;
    public GameObject textPopup;
    MeshRenderer text;
    public AudioSource doorSound;
    public GameObject player;

    public Button ib;
    public GameObject interactButton;
    public GameObject jumpButton;

    public GameObject blackOutSquare;

    private void Start()
    {
        text = textPopup.GetComponent<MeshRenderer>();
        text.enabled = false;
        Button btn = ib.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
    void OnTriggerStay2D(Collider2D hitBox)
    {
        if (hitBox.tag == "Player")
        {
            interactButton.SetActive(true);
            jumpButton.SetActive(false);
            radius = true;
            text.enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            interactButton.SetActive(false);
            jumpButton.SetActive(true);
            radius = false;
            text.enabled = false;
        }
    }
    public void TaskOnClick()
    {
        if (radius == true)
        {
            StartCoroutine(FadeBlackOutSquare());
            Invoke("LoadScene", 2);
            doorSound.Play();
        }
    }

    void LoadScene()
    {
        SceneManager.LoadScene("The End");
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
