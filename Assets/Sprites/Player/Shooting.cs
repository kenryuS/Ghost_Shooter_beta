using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    
    public Transform shoot_point;
    public GameObject bulletPrefab;

    public GameObject player;

    public AudioSource audioSource;

    public AudioClip[] audioClips;
    
    public float bulletForce = 16f;
    
    private bool cooldown = false;
    public float fireRate = 0.3f;
    public float damage = 1;
    
    void Start()
    {
        if (weaponselect.wval == 0) {
            this.fireRate = 0.2f;
            this.damage = 1.0f;
        }
        
        else if (weaponselect.wval == 1) {
            this.fireRate = 0.6f;
            this.damage = 2.0f;
        }
        
        else if (weaponselect.wval == 2) {
            this.fireRate = 1.5f;
            this.damage = 5.0f;
        }
        if (gameManagerScript.diffvalfact > 1.0f) {this.damage *= gameManagerScript.diffvalfact;}
    }
    
    // Update is called once per frame
    void Update()
    {
        if (gameManagerScript.isPaused == true) {return;}
        if ((player.GetComponent<Player>().Controltype == 0 && Input.GetKey(KeyCode.Z)) && this.cooldown == false)
        {
            ShootTheBullet();
        }
        
        if ((player.GetComponent<Player>().Controltype == 1 && Input.GetKey(KeyCode.Space)) && this.cooldown == false)
        {
            ShootTheBullet();
        }
        
        if ((player.GetComponent<Player>().mouseenable == true && Input.GetMouseButton(0)) && this.cooldown == false)
        {
            ShootTheBullet();
        }
    }

    void ShootTheBullet() {
        Shoot();
        audioSource.PlayOneShot(audioClips[weaponselect.wval],sevolumeslide.seVolume);
        Invoke("ResetCooldown", this.fireRate);
        this.cooldown = true;
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
