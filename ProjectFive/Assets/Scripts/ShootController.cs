using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    public bool isFiring;
    public PlayerBullet bullet;
    public float bulletSpeed;
    public float timeBetweenShots;
    private float shotCounter;
    public Transform firePoint;
    public FloatReference playerFireRate;

    void Update()
    {
        IsThePlayerFiring();
    }

    private void IsThePlayerFiring()
    {
        //abstract these methods at some point
        if (isFiring)
        {
            shotCounter -= Time.deltaTime;
            if(shotCounter <= 0)
            {
                shotCounter = playerFireRate.Value;
                PlayerBullet newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as PlayerBullet;
                newBullet.bulletSpeed = bulletSpeed;
            }
        }
        else
        {
            shotCounter = 0;
        }
    }
}
