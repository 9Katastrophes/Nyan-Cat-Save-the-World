using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public enum GameState { menu, getReady, playing, gameOver };

public class GameManager : MonoBehaviour
{
    public static GameManager S;

    public GameState gameState;

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

    public void TriggerSecretMode()
    {
        infiniteMode = !infiniteMode;
        Debug.Log("Infinite Mode: " + infiniteMode.ToString());
    }

    public void AwardPoints(int points)
    {
        score += points;
    }
}
