using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.parent = null;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = (Vector3.right * speed);
        Destroy(this.gameObject, 3.0f);
    }
}
