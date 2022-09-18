using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    
    public Transform shoot_point;
    public GameObject bulletPrefab;
    
    public float bulletForce = 16f;
    
    private bool cooldown = false;
    public float fireRate = 0.3f;
    public float damage = 1;
    
    void Start()
    {
        if (this.fireRate <= 0.3f) this.damage = 1.0f;
        
        else if (this.fireRate <= 0.6f) this.damage = 2.0f;
        
        else if (this.fireRate <= 1.5f) this.damage = 5.0f;
    }
    
    // Update is called once per frame
    void Update()
    {
        if ((GameObject.Find("player").GetComponent<Player>().Controltype == 1 && Input.GetKey(KeyCode.Z)) && this.cooldown == false)
        {
            Shoot();
            Invoke("ResetCooldown",this.fireRate);
            cooldown = true;
        }
        
        if ((GameObject.Find("player").GetComponent<Player>().Controltype == 2 && Input.GetKey(KeyCode.Space)) && this.cooldown == false)
        {
            Shoot();
            Invoke("ResetCooldown",this.fireRate);
            cooldown = true;
        }
        
        if ((GameObject.Find("player").GetComponent<Player>().mouseenable == true && Input.GetMouseButton(0)) && this.cooldown == false)
        {
            Shoot();
            Invoke("ResetCooldown",this.fireRate);
            cooldown = true;
        }
    }
    
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, shoot_point.position, shoot_point.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(shoot_point.right * bulletForce, ForceMode2D.Impulse);
    }
    
    void ResetCooldown()
    {
        this.cooldown = false;
    }
}
