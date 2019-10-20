using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyHealth;
    [SerializeField] private Player player;

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
            enemyHealth -= 1;
        }

        if(collision.gameObject.tag == "Player")
        {
            player.playerCurrentHealth -= 1;
        }
    }
}
