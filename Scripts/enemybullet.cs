using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemybullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject enemy1;
    public GameObject enemy2;

    private void Update()
    {
        if (Vector2.Distance(Vector2.zero, rb.position) > 300)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
