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

    public void Shoot()
    {
        GameObject bullet = Instantiate(playerBulletPrefab, this.transform);
    }
}
