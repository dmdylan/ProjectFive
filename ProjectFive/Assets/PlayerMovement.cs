using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Rigidbody rigidBody;
    public float speed = 10.0f;
    private float jumpSpeed = 6.0f;
    private float gravity = 20.0f;
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
    }

    private void Movement()
    {
        if (characterController.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection *= speed;
        }
        if (Input.GetButtonDown("Jump"))
        {
            moveDirection.y = jumpSpeed;
        }
        moveDirection.y -= gravity * Time.deltaTime;

        characterController.Move(moveDirection * Time.deltaTime);
    }



    /*
    private void Movement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if(Input.GetKey(KeyCode.W))
        {
            rigidBody.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rigidBody.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            rigidBody.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed;
        }
        else if(Input.GetKey(KeyCode.A))
        {
            rigidBody.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed;
        }
        
    }
    */


}
