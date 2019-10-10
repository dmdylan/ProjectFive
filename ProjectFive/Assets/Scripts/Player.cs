using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerHealth = 10;
    public float speed = 10.0f;
    private Vector3 moveDirection = Vector3.zero;
    public GameObject projectile;
    private float bulletSpawnOffset = 0.5f;
    int groundMask;
    float camRayLength;
    Rigidbody playerRigidBody;
    private Vector3 moveVelocity;
    private Camera mainCamera;

    void Awake()
    { 
        playerRigidBody = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
        groundMask = LayerMask.GetMask("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        HealthIsZero();
        //PlayerFiresBullet();
    }

    void FixedUpdate()
    {
        RotatePlayer();
        Movement();
    }

    private void Movement()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        moveVelocity = moveDirection * speed;
        playerRigidBody.velocity = moveVelocity;
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

    private void RotatePlayer()
    {
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

        if (groundPlane.Raycast(cameraRay, out camRayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(camRayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.black);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
    }
}
