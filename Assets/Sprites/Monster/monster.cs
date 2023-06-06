using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster : MonoBehaviour
{

    public float HP;

    public float fireRate = 1.0f;

    public GameObject bulletPrefab;

    public Transform shootPoint;

    private float delta = 0;

    private int Angle;

    public bool isShooting;

    // Start is called before the first frame update
    void Start()
    {
        if (diffslide.diffval == 1.0f) {
            this.HP = Random.Range(3,8);
        } else if (diffslide.diffval == 2.0f) {
            this.HP = Random.Range(6,10);
        } else if (diffslide.diffval == 3.0f) {
            this.HP = Random.Range(12,15);
        }
        this.Angle = Random.Range(-80, 81);
        Quaternion rotation = Quaternion.AngleAxis(this.Angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 1);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "playerBullet")
        {
            this.HP -= GameObject.Find("player").GetComponent<Shooting>().damage;
            if (this.HP <= 0)
            {
                gameObject.SetActive(false);
                Scoreui.addMonsterKill();
				gameManagerScript.monsterKilled += 1;
                Destroy(gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.position.x) > 8.0f) Destroy(gameObject);
        if (Mathf.Abs(transform.position.y) > 7.0f) Destroy(gameObject);
    }

    void FixedUpdate()
    {
        if (gameManagerScript.isPaused == true) {return;}
        this.delta += Time.fixedDeltaTime;
        if ((this.delta > this.fireRate) && (this.isShooting == true))
        {
            this.delta = 0;
            shooting();
        }
        transform.Translate(-0.02f * gameManagerScript.diffvalfact, 0, 0);
    }

    void shooting()
    {
        Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
    }
}
