using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    private void Update()
    {
        if (Vector2.Distance(Vector2.zero, rb.position) > 200)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            Destroy(gameObject);
        }
        else if(collision.gameObject.tag == "enemy2")
        {
            Destroy(gameObject);
        }
    }


}

