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
        this.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * bulletSpeed);
        print("bullet moved");
    }

    private Vector3 GetMousePosition()
    {
        Vector3 aimPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        aimPos.y = 0.5f;

        return aimPos;
    }
}
