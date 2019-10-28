using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int playerStartingHealth;
    public int playerCurrentHealth;
    public float speed = 10.0f;
    private Vector3 moveDirection = Vector3.zero;
    float camRayLength;
    Rigidbody playerRigidBody;
    private Vector3 moveVelocity;
    private Camera mainCamera;
    public ShootController shoot;
    public int playerPoints;

    void Awake()
    { 
        playerRigidBody = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
    }

    private void Start()
    {
        SetPlayerHealthAtGameStart();
        SetPlayerPointsAtGameStart();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerFiresBullet();
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

    private void PlayerFiresBullet()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            shoot.isFiring = true;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            shoot.isFiring = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {        
            Destroy(collision.gameObject);            
        }
    }

    private void SetPlayerHealthAtGameStart()
    {
        playerStartingHealth = 20;
        playerCurrentHealth = playerStartingHealth;
    }

    private void SetPlayerPointsAtGameStart()
    {
        playerPoints = 0;
    }
}
