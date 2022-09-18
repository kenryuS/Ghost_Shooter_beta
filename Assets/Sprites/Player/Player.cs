using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    float speed = 4.0f;
    int rotspeed = 1;
    Vector2 control;
    public Rigidbody2D rb;
    public int Controltype;
    public bool mouseenable;

    void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene("GameOver");
    }

    void control1()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) this.control.x = -1;
        if (Input.GetKey(KeyCode.RightArrow)) this.control.x = 1;
        if (Input.GetKey(KeyCode.UpArrow)) this.control.y = 1;
        if (Input.GetKey(KeyCode.DownArrow)) this.control.y = -1;
    }

    void control2()
    {
        if (Input.GetKey(KeyCode.A)) this.control.x = -1;
        if (Input.GetKey(KeyCode.D)) this.control.x = 1;
        if (Input.GetKey(KeyCode.W)) this.control.y = 1;
        if (Input.GetKey(KeyCode.S)) this.control.y = -1;
    }

    void playercontrol()
    {
        if (this.Controltype == 1) control1();
        if (this.Controltype == 2) control2();
        if (this.mouseenable == true) controlmouse();

        rb.MovePosition(rb.position + this.control * this.speed * Time.deltaTime);
        this.control *= 0.9f;
    }

    void controlmouse()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, this.rotspeed);
    }

    void FixedUpdate()
    {
        playercontrol();
    }
}
