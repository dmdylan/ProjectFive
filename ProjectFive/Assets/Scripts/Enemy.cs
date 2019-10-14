using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyHealth;
    public Player player;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HealthIsZero();
    }

    private void HealthIsZero()
    {
        if(enemyHealth <= 0)
        {
            Object.Destroy(gameObject);
            player.playerPoints += 5;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "PlayerBullet")
        {
            Debug.Log("Bullet hit enemy");
            enemyHealth -= 1;
        }
    }
}
