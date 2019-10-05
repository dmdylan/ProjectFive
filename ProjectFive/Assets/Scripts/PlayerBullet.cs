using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public int bulletSpeed;
    private float bulletLife;
    private float bulletSpawnTime;

    private void Awake()
    {
        bulletSpawnTime = Time.time;
    }
    void Update()
    {
        BulletMovement();
        BulletLife();
    }

    private void BulletLife()
    {
        bulletLife = Time.time - bulletSpawnTime;
        if(bulletLife >= 3)
        {
            Object.Destroy(gameObject);
        }
    }

    private void BulletMovement()
    {
               
        this.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
        print("bullet moved");
    }

    private void OnCollisionEnter(Collision collision)
    {

    }
}
