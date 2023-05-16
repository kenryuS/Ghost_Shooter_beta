using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    
    public float speed = 10f;

    private Vector2 v;

    public void Start()
    {
        rb.velocity = transform.right * speed * -1f;
        v = rb.velocity;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") Destroy(gameObject);
    }

    void FixedUpdate()
    {
        if (gameManagerScript.isPaused == true) {
            rb.velocity = new Vector2(0.0f,0.0f);
            return;
        }
        else {rb.velocity = v;}
        if (Mathf.Abs(transform.position.x) > 8.0f) Destroy(gameObject);
        if (Mathf.Abs(transform.position.y) > 7.0f) Destroy(gameObject);
    }
}
