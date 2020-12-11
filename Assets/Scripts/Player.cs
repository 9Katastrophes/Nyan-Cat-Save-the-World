using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float maxOffset;
    public GameObject playerBulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = transform.position;
        currentPosition.y += (Input.GetAxisRaw("Vertical") * speed * Time.deltaTime);
        currentPosition.y = Mathf.Clamp(currentPosition.y, -maxOffset, maxOffset);
        transform.position = currentPosition;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
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

    public void Die()
    {
        Debug.Log("Player died!");
        GetComponent<BoxCollider2D>().enabled = false;
        speed = 0;
        GetComponent<Animator>().SetTrigger("Death");
        SoundManager.S.PlayPlayerDeathSound();
        //TODO: go to game end state where everything freezes except for player
    }
}
