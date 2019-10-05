using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Rigidbody rigidBody;
    public int playerHealth = 10;
    public float speed = 10.0f;
    CharacterController characterController;
    private Vector3 moveDirection = Vector3.zero;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        HealthIsZero();
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
}
