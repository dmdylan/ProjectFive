using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCollisions : MonoBehaviour
{
    Player player;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    /*
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //print(collision.gameObject.tag);
            Destroy(collision.gameObject);
            player.playerHealth -= 1;
        }
    }
    */
}
