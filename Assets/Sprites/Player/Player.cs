using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    float speed = 4.0f;
    int rotspeed = 1;
    int pRemains = 3;
    bool cooldown = false;
    Vector2 control;
    public Rigidbody2D rb;
    public int Controltype;
    public bool mouseenable;

    void Start() {
        playerRemains.remains = this.pRemains;
        GameObject.Find("playerRemain").GetComponent<playerRemains>().updateValue();
        this.Controltype = controlAssetSelector.contVal;
        this.mouseenable = toggleMouseCont.mctVal;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.cooldown == false) {
            this.pRemains -= 1;
            GameObject.Find("playerRemain").GetComponent<playerRemains>().updateui();}
        if (this.pRemains < 0) {
            gameManagerScript.playerDied();
        }
        Invoke("collisionCoolDown", 3.0f);
        this.cooldown = true;
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
        if (this.Controltype == 0) control1();
        if (this.Controltype == 1) control2();
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

    void collisionCoolDown() {
        this.cooldown = false;
    }

    void FixedUpdate()
    {
        if (gameManagerScript.isPaused == true) {return;}
        playercontrol();
        Vector3 minScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector3 maxScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,0));
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minScreenBounds.x + 0.5f, maxScreenBounds.x - 0.5f),Mathf.Clamp(transform.position.y, minScreenBounds.y + 0.5f, maxScreenBounds.y - 0.5f), transform.position.z);
    }
}
