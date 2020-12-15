using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum GameState { menu, getReady, playing, gameOver };

public class GameManager : MonoBehaviour
{
    public static GameManager S;

    public GameState gameState;

    public TextMeshProUGUI scoreOverlay;
    public TextMeshProUGUI messageOverlay;
    public Button restartButton;
    public Button menuButton;

    public int score = 0;

    // secret settings
    public bool infiniteMode = false;

    private void Awake()
    {
        if (GameManager.S)
        {
            Destroy(this.gameObject);
        }
        else
        {
            S = this;
        }

        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        SceneManager.activeSceneChanged += SetUpGame;

        // this is needed if we initially start in the game scene
        if (SceneManager.GetActiveScene().name == "NyanCatGame")
        {
            ResetScore();
            scoreOverlay.text = "Score:" + score;
            scoreOverlay.enabled = true;
            messageOverlay.enabled = false;
            restartButton.gameObject.SetActive(false);
            menuButton.gameObject.SetActive(false);

            StartCoroutine(GetReady());
        }
    }

    public void TriggerSecretMode()
    {
        infiniteMode = !infiniteMode;
        Debug.Log("Infinite Mode: " + infiniteMode.ToString());
    }

    public void AwardPoints(int points)
    {
        score += points;
        scoreOverlay.text = "Score:" + score;
    }

    public void ResetScore()
    {
        score = 0;
    }

    private void SetUpGame(Scene current, Scene next)
    {
        if (next.name == "NyanCatGame")
        {
            ResetScore();
            scoreOverlay = GameObject.Find("ScoreOverlay").GetComponent<TextMeshProUGUI>();
            messageOverlay = GameObject.Find("MessageOverlay").GetComponent<TextMeshProUGUI>();
            scoreOverlay.text = "Score:" + score;
            scoreOverlay.enabled = true;
            messageOverlay.enabled = false;

            restartButton = GameObject.Find("RestartButton").GetComponent<Button>();
            menuButton = GameObject.Find("MenuButton").GetComponent<Button>();
            restartButton.gameObject.SetActive(false);
            menuButton.gameObject.SetActive(false);

            StartCoroutine(GetReady());
        }
        else
            gameState = GameState.menu;
    }

    public IEnumerator GetReady()
    {
        gameState = GameState.getReady;

        messageOverlay.text = "Stop\nPepper Lord!";
        messageOverlay.enabled = true;

        yield return new WaitForSeconds(2.0f);

        if (infiniteMode)
            messageOverlay.text = "Infinite Mode!\nGet Ready!";
        else
            messageOverlay.text = "Get Ready!";

        yield return new WaitForSeconds(2.0f);

        messageOverlay.enabled = false;
        gameState = GameState.playing;
    }

    public void GameOver(bool playerWon)
    {
        gameState = GameState.gameOver;

        if (playerWon)
            messageOverlay.text = "You Won!";
        else
            messageOverlay.text = "Game Over!";
        messageOverlay.text += "\nFinal Score:" + score;
        messageOverlay.enabled = true;
        restartButton.gameObject.SetActive(true);
        menuButton.gameObject.SetActive(true);
    }
}
