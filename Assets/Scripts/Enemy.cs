using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject enemySpawner;

    public float speed = 0;
    public int direction = -1; // initial y direction for enemies
    public float maxOffset = 0;

    public int value = 0;

    public GameObject enemyBulletPrefab;
    public float fireRate = 0.0f;
    public float randomFireOffset = 0.0f;
    private float timeLeftToShoot;

    void Start()
    {
        timeLeftToShoot = fireRate + Random.Range(0.0f, randomFireOffset);
        enemySpawner = GameObject.Find("EnemySpawner");
    }

    void Update()
    {
        if (Mathf.Abs(transform.position.y) >= maxOffset)
            direction = -direction;

        Vector3 currentPosition = transform.position;
        currentPosition.y += direction * speed * Time.deltaTime;
        currentPosition.y = Mathf.Clamp(currentPosition.y, -maxOffset, maxOffset);
        transform.position = currentPosition;

        if (timeLeftToShoot > 0)
        {
            timeLeftToShoot -= Time.deltaTime;
        }
        else
        {
            Fire();
            timeLeftToShoot = fireRate + Random.Range(0.0f, randomFireOffset);
        }
    }

    private void Fire()
    {
        Instantiate(enemyBulletPrefab, this.transform);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            Die();
        }
        if (collision.gameObject.tag == "Back Wall") // went out of bounds
        {
            Destroy(this.gameObject);
            enemySpawner.GetComponent<EnemySpawner>().EnemyKilled();
        }
    }

    private void Die()
    {
        Debug.Log("Enemy died!");
        Destroy(this.gameObject, 0.5f);
        enemySpawner.GetComponent<EnemySpawner>().EnemyKilled();
        GetComponent<CircleCollider2D>().enabled = false;
        speed = 0;
        GetComponent<Animator>().SetTrigger("Death");
        SoundManager.S.PlayEnemyDeathSound();
        GameManager.S.AwardPoints(value);
    }
}
