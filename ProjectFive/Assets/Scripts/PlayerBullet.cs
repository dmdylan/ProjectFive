using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float bulletSpeed;
    private float bulletLife;
    private float bulletSpawnTime;
    public GameObject projectile;
    private Player player;
    private Collider bullet;

    private void Start()
    {
        bulletSpawnTime = Time.time;
        //Collider bulletCollider = Instantiate(bullet) as Collider;
        //Rigidbody bullet = Instantiate(PlayerBullet) as Rigidbody;
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
        transform.Translate(Vector3.forward * bulletSpeed);
    }

    private Vector3 GetMousePosition()
    {
        Vector3 aimPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        aimPos.y = 0.5f;
        return aimPos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //Physics.IgnoreCollision(bulletCollider.GetComponent<Collider>(), player.GetComponent<Collider>());
        }

        Destroy(this.gameObject);
    }
}
