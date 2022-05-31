using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AircraftMovement : MonoBehaviour
{
    public static AircraftMovement instance;
    public FixedJoystick joystick;
    private Rigidbody rb;
    public float forwardSpeed = 0;
    public float forwardSpeedMultiplier = 100;
    public float speedMultiplier = 1000;
    public float horizontalSpeed, verticalSpeed = 4;
    public float smoothness, rotationSmoothnees = 5;
    public float maxHoriRotation = 0.6f;
    public float maxVertiRotation = 0.06f;
    public float Hori, Verti;

    private void Awake() //Singleton
    {
        if (instance == null)
        {
            instance = this;
        }
    }



    private void Start()
    {

        rb = GetComponent<Rigidbody>();

    }
    void Update()
    {

        JoystickController();  // This is Horizotal and Vertical Controller.
        HandlePlaneRotation(); // This is aircraft's rotation controller.

    }


    private void FixedUpdate()
    {
        HandlePlaneMove();
    }

    public void JoystickController()
    {
        if (Input.GetMouseButton(0) || Input.touches.Length != 0)
        {
            Hori = joystick.Horizontal;
            Verti = joystick.Vertical;
        }
        else
        {
            Hori = Input.GetAxisRaw("Horizontal");
            Verti = Input.GetAxisRaw("Vertical");
        }
    }

    private void HandlePlaneRotation()
    {
        float horizontalRotation = Hori * maxHoriRotation;
        float verticalRotation = -Verti * maxVertiRotation;


        transform.rotation = Quaternion.Lerp(transform.rotation, new Quaternion(-verticalRotation, Hori * 0.1f, -horizontalRotation, transform.rotation.w), Time.deltaTime * rotationSmoothnees);

    }

    private void HandlePlaneMove()
    {
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, forwardSpeed * forwardSpeedMultiplier * Time.deltaTime);

        float xVelocity = Hori * speedMultiplier * horizontalSpeed * Time.deltaTime;
        float yVelocity = -Verti * speedMultiplier * verticalSpeed * Time.deltaTime;


        rb.velocity = Vector3.Lerp(rb.velocity, new Vector3(xVelocity, yVelocity, rb.velocity.z), Time.deltaTime * smoothness);
    }

}
