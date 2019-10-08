﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Rigidbody rigidBody;
    public int playerHealth = 10;
    public float speed = 10.0f;
    CharacterController characterController;
    private Vector3 moveDirection = Vector3.zero;
    public GameObject projectile;
    private float bulletSpawnOffset = 0.5f;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        HealthIsZero();
        PlayerFiresBullet();
    }

    private void Movement()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection *= speed;
        characterController.Move(moveDirection * Time.deltaTime);
    }

    private void HealthIsZero()
    {
        if(playerHealth <= 0)
        {
            //todo add player destroyed. Maybe change state?
            print("player ded");
        }
    }

    private void PlayerFiresBullet()
    {
        //Vector3 bulletSpawnLocation = transform.position;
        //bulletSpawnLocation.y = 1f;

        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate(projectile,transform.position, transform.rotation);
            Physics.IgnoreCollision(bullet.GetComponent<Collider>(), this.gameObject.GetComponent<Collider>());
            print("mouse button pressed, firing bullet");
        }
    }
}
