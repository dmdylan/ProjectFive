using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    Collider powerUpCollider;

    private void Start()
    {
        powerUpCollider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameManagement.playerPickedUpPowerUp = true;
            Destroy(this.gameObject);
        }
    }
}
