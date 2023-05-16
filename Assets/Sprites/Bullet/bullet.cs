using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    public GameObject hiteffect;
    public Rigidbody2D rb;

    private Vector2 v;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Monster") {
            GameObject effect = Instantiate(hiteffect) as GameObject;
            effect.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            Destroy(gameObject);
            Destroy(effect, 0.8f);
        }
    }

    void Start() {
        v = rb.velocity;
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
