﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyHealth;

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
        }
    }
}
