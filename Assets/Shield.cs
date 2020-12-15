using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.parent = null;
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        this.transform.position = player.transform.position + new Vector3(2.0f, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            SoundManager.S.PlayShieldSound();
            player.GetComponent<Player>().hasShield = false;
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
