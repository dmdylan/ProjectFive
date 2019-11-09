using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static float playerStartingHealth = 20f;
    public static float playerCurrentHealth;
    public static float playerMaxSlowTimeEnergy = 1f;
    public static float playerCurrentSlowTimeEnergy;
    private bool cannotTeleport;
    public float speed = 10.0f;
    private Vector3 moveDirection = Vector3.zero;
    float camRayLength;
    Rigidbody playerRigidBody;
    private Vector3 moveVelocity;
    private Camera mainCamera;
    public ShootController shoot;
    private bool timeShiftActive;
    public static float playerTeleportTimer = 10f;

    void Awake()
    { 
        playerRigidBody = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerFiresBullet();
        PlayerTimeControlAbility();
        ManagePlayerTimeSlowEnergy();
        CanPlayerTeleport();
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
            playerCurrentHealth -= 1;
        }
    }

    private void PlayerTeleportAbility()
    {            
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (groundPlane.Raycast(cameraRay, out camRayLength))
            {
                Vector3 pointToLook = cameraRay.GetPoint(camRayLength);
                transform.position = new Vector3(pointToLook.x, transform.position.y, pointToLook.z);
            }
            cannotTeleport = true;
        }
    }

    private void CanPlayerTeleport()
    {
        if (cannotTeleport == true)
        {
            playerTeleportTimer -= Time.deltaTime;
            if(playerTeleportTimer < 0)
            {
                cannotTeleport = false;
                playerTeleportTimer = 10f;
            }
        }
        else
        {
            PlayerTeleportAbility();
        }
    }

    private void PlayerTimeControlAbility()
    {
        if (timeShiftActive == false)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && playerCurrentSlowTimeEnergy > 0)
            {
                Time.timeScale = .5f;
                timeShiftActive = true;
            }
            else
            {
                Time.timeScale = 1f;
                timeShiftActive = false;
            }
        }
    }

    private void ManagePlayerTimeSlowEnergy()
    {
        //todo fix this so it isn't tied to framerate 
        if (timeShiftActive == true)
        {
            playerCurrentSlowTimeEnergy -= .01f;
            if (playerCurrentSlowTimeEnergy <= 0)
            {
                timeShiftActive = false;
            }
        }
        else
        {
            playerCurrentSlowTimeEnergy += .01f;
            if(playerCurrentSlowTimeEnergy >= playerMaxSlowTimeEnergy)
            {
                playerCurrentSlowTimeEnergy = playerMaxSlowTimeEnergy;
            }
        }
    }
}
