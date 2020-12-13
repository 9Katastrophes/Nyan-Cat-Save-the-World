using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    private Vector2 velocity;

    private void Awake()
    {
        velocity = Vector2.left * speed;
    }

    void Start()
    {
        this.transform.parent = null;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = velocity;
        Destroy(this.gameObject, 3.0f);
    }

    public void ResetVelocity(Vector2 newVelocity)
    {
        velocity = (newVelocity * speed);          
    }
}
