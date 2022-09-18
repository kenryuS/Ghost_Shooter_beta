using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    
    public float speed = 10f;
    
    public void Start()
    {
		rb.velocity = transform.right * speed * -1f;
	}
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") Destroy(gameObject);
    }

    void FixedUpdate()
    {
        if (Mathf.Abs(transform.position.x) > 8.0f) Destroy(gameObject);
        if (Mathf.Abs(transform.position.y) > 7.0f) Destroy(gameObject);
    }
}
