using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public float speed = 30f;
    public float retreatspeed = 40f;
    public float stoppingdistance = 100f;
    public float retreatdistance = 50f;
    public float timer = 5f;
    public float bulletforce = 100f;
    public Transform firepoint;
    public Rigidbody2D rb;
    public GameObject bulletprefab;
    private Rigidbody2D target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 lookdir = target.position - rb.position;
        float angle = Mathf.Atan2(lookdir.y, lookdir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
        if(Vector2.Distance(rb.position, target.position) > stoppingdistance)
        {
            rb.position = Vector2.MoveTowards(rb.position, target.position, speed * Time.deltaTime);
        }
        if(Vector2.Distance(rb.position, target.position) < retreatdistance)
        {
            rb.position = Vector2.MoveTowards(rb.position, target.position, -retreatspeed * Time.deltaTime);
        }

        timer = timer - 1 * Time.deltaTime;
        Debug.Log(timer);
        if(timer <= 0)
        {
            GameObject bullet = Instantiate(bulletprefab, firepoint.position, firepoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firepoint.up * bulletforce, ForceMode2D.Impulse);
            timer = 5;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        else if(collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
}
