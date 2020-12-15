using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager S;

    public AudioSource audio;
    public AudioClip buttonSound;
    public float buttonVolume = 1.0f;
    public AudioClip playerShootingSound;
    public float playerShootingVolume = 1.0f;
    public AudioClip shieldSound;
    public float shieldVolume = 1.0f;
    public AudioClip enemyShootingSound;
    public float enemyShootingVolume = 1.0f;
    public AudioClip enemyDeathSound;
    public float enemyDeathVolume = 1.0f;
    public AudioClip playerDeathSound;
    public float playerDeathVolume = 1.0f;

    private void Awake()
    {
        if (SoundManager.S)
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
        audio = GetComponent<AudioSource>();
    }

    public void PlayButtonSound()
    {
        audio.PlayOneShot(buttonSound, buttonVolume);
    }

    public void PlayPlayerShootingSound()
    {
        audio.PlayOneShot(playerShootingSound, playerShootingVolume);
    }

    public void PlayShieldSound()
    {
        audio.PlayOneShot(shieldSound, shieldVolume);
    }

    public void PlayEnemyShootingSound()
    {
        audio.PlayOneShot(enemyShootingSound, enemyShootingVolume);
    }

    public void PlayEnemyDeathSound()
    {
        audio.PlayOneShot(enemyDeathSound, enemyDeathVolume);
    }

    public void PlayPlayerDeathSound()
    {
        audio.PlayOneShot(playerDeathSound, playerDeathVolume);
    }
}
