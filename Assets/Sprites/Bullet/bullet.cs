using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    public GameObject hiteffect;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Monster") {
            GameObject effect = Instantiate(hiteffect) as GameObject;
            effect.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            Destroy(gameObject);
            Destroy(effect, 0.8f);
        }
    }

    void FixedUpdate()
    {
        if (Mathf.Abs(transform.position.x) > 8.0f) Destroy(gameObject);
        if (Mathf.Abs(transform.position.y) > 7.0f) Destroy(gameObject);
    }
}
