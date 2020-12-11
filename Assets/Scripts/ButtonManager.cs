using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager S;

    // secret settings
    public Button secretButton;
    public Sprite[] secretSprites;

    private void Awake()
    {
        if (ButtonManager.S)
        {
            Destroy(this.gameObject);
        }
        else
        {
            S = this;
        }
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            secretButton = GameObject.Find("Secret Button").GetComponent<Button>();
            if (GameManager.S.infiniteMode)
                secretButton.GetComponent<Image>().sprite = secretSprites[1];
            else
                secretButton.GetComponent<Image>().sprite = secretSprites[0];
        }
    }

    public void btn_Menu()
    {
        SoundManager.S.PlayButtonSound();
        SceneManager.LoadScene("Menu");
    }

    public void btn_Play()
    {
        SoundManager.S.PlayButtonSound();
        SceneManager.LoadScene("NyanCatGame");
    }

    public void btn_Instructions()
    {
        SoundManager.S.PlayButtonSound();
        SceneManager.LoadScene("Instructions");
    }

    public void btn_Credits()
    {
        SoundManager.S.PlayButtonSound();
        SceneManager.LoadScene("Credits");
    }

    public void btn_SecretMode()
    {
        SoundManager.S.PlayButtonSound();
        GameManager.S.TriggerSecretMode();
        if (GameManager.S.infiniteMode)
            secretButton.GetComponent<Image>().sprite = secretSprites[1];
        else
            secretButton.GetComponent<Image>().sprite = secretSprites[0];
    }

    public void btn_Quit()
    {
        SoundManager.S.PlayButtonSound();
        Debug.Log("Quit!");
        Application.Quit();
    }
}
