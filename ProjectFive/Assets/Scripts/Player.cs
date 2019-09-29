using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Rigidbody rigidBody;
    public float speed = 10.0f;
    CharacterController characterController;
    private Vector3 moveDirection = Vector3.zero;
    private float xPos { get; set; }
    private float yPos { get; set; }
    private float zPos { get; set; }

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
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection *= speed;
        characterController.Move(moveDirection * Time.deltaTime);
    }

    public float GetXPos()
    {
        return xPos = transform.position.x;
    }

    public float GetYPos()
    {
        return yPos = transform.position.y;
    }

    public float GetZPos()
    {
        return zPos = transform.position.z;
    }

}
