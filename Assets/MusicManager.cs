using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public static MusicManager S;

    public AudioSource audio;
    public AudioClip menuMusic;
    public AudioClip gameMusic;

    private void Awake()
    {
        if (MusicManager.S)
        {
            Destroy(this.gameObject);
        }
        else
        {
            S = this;
        }

        DontDestroyOnLoad(this);
    }

    void Start()
    {
        SceneManager.activeSceneChanged += ChangeMusic;

        audio = GetComponent<AudioSource>();
        if (SceneManager.GetActiveScene().name == "NyanCatGame")
            PlayMusic("game");
        else
            PlayMusic("menu");
    }

    private void ChangeMusic(Scene current, Scene next)
    {
        if (current.name != "NyanCatGame" && next.name == "NyanCatGame")
            PlayMusic("game");
        if (current.name == "NyanCatGame" && next.name != "NyanCatGame")
            PlayMusic("menu");
    }

    public void PlayMusic(string songName)
    {
        switch (songName)
        {
            case "menu":
                audio.clip = menuMusic;
                break;
            case "game":
                audio.clip = gameMusic;
                break;
            default:
                Debug.Log("Invalid song name");
                break;
        }

        audio.Play();
    }
}
