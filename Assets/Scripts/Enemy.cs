using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 0;
    public int direction = -1;
    public float maxOffset = 0;

    public int value = 0;

    public GameObject enemyBulletPrefab;
    public float fireRate = 5.0f;
    private float timeLeftToShoot;

    // Start is called before the first frame update
    void Start()
    {
        timeLeftToShoot = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.position.y) > maxOffset)
            direction = -direction;

        Vector3 currentPosition = transform.position;
        currentPosition.y += direction * speed * Time.deltaTime;
        transform.position = currentPosition;

        if (timeLeftToShoot > 0)
        {
            timeLeftToShoot -= Time.deltaTime;
        }
        else
        {
            Fire();
            timeLeftToShoot = fireRate;
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
    }

    private void Die()
    {
        Debug.Log("Enemy died!");
        Destroy(this.gameObject, 0.5f);
        GetComponent<CircleCollider2D>().enabled = false;
        speed = 0;
        GetComponent<Animator>().SetTrigger("Death");
        SoundManager.S.PlayEnemyDeathSound();
        GameManager.S.AwardPoints(value);
    }
}
