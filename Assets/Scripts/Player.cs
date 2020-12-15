using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;
    public float maxOffset;
    public GameObject playerBulletPrefab;
    public GameObject shieldPrefab;
    public bool hasShield = false;

    void Update()
    {
        if (GameManager.S.gameState == GameState.playing)
        {
            Vector3 currentPosition = transform.position;
            currentPosition.y += (Input.GetAxisRaw("Vertical") * speed * Time.deltaTime);
            currentPosition.y = Mathf.Clamp(currentPosition.y, -maxOffset, maxOffset);
            transform.position = currentPosition;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shoot();
            }
            if (!hasShield && (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
            {
                MakeShield();
            }
        }
        if (GameManager.S.gameState == GameState.gameOver)
        {
            DisableMovement();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Die();
        }
    }

    public void Shoot()
    {
        Instantiate(playerBulletPrefab, this.transform);
        SoundManager.S.PlayPlayerShootingSound();
    }

    public void MakeShield()
    {
        hasShield = true;
        Instantiate(shieldPrefab, this.transform);
        SoundManager.S.PlayShieldSound();
    }

    public void DisableMovement()
    {
        GetComponent<Player>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
    }

    public void Die()
    {
        Debug.Log("Player died!");
        DisableMovement();
        GetComponent<Animator>().SetTrigger("Death");
        SoundManager.S.PlayPlayerDeathSound();
        GameManager.S.GameOver(false);
    }
}
