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
        if (next.name == "NyanCatGame")
            PlayMusic("game");
        if (next.name == "Menu")
            PlayMusic("menu");
    }

    public void PlayMusic(string songName)
    {
        AudioClip newSong = null;
        switch (songName)
        {
            case "menu":
                newSong = menuMusic;
                break;
            case "game":
                newSong = gameMusic;
                break;
            default:
                Debug.Log("Invalid song name");
                break;
        }

        if (audio.clip != newSong)
        {
            audio.clip = newSong;
            audio.Play();
        }
    }
}
