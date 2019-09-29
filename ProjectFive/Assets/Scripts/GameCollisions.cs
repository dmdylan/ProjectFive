using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCollisions : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    { 
        if(collision.gameObject.tag == "Enemy")
        {
            //print(collision.gameObject.tag);
            Destroy(collision.gameObject);
        }
    }
}
