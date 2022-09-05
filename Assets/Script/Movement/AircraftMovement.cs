using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AircraftMovement : MonoBehaviour
{
    public static AircraftMovement instance;
    public FixedJoystick joystick;
    private Rigidbody rb;

    #region Movement
    private float forwardSpeed = 0;
    private float forwardSpeedMultiplier = 100;
    private float speedMultiplier = 1000;
    private float horizontalSpeed, verticalSpeed = 4;
    private float smoothness, rotationSmoothnees = 5;
    private float maxHoriRotation = 0.6f;
    private float maxVertiRotation = 0.06f;
    private float Hori, Verti; 
    #endregion

    public float ForwardSpeed { get => forwardSpeed; set => forwardSpeed = value; }
    public float ForwardSpeedMultiplier { get => forwardSpeedMultiplier; set => forwardSpeedMultiplier = value; }
    public float SpeedMultiplier { get => speedMultiplier; set => speedMultiplier = value; }
    public float HorizontalSpeed { get => HorizontalSpeed1; set => HorizontalSpeed1 = value; }
    public float HorizontalSpeed1 { get => horizontalSpeed; set => horizontalSpeed = value; }
    public float Smoothness { get => Smoothness1; set => Smoothness1 = value; }
    public float Smoothness1 { get => smoothness; set => smoothness = value; }
    public float MaxHoriRotation { get => maxHoriRotation; set => maxHoriRotation = value; }
    public float MaxVertiRotation { get => maxVertiRotation; set => maxVertiRotation = value; }
    public float Hori1 { get => Hori2; set => Hori2 = value; }
    public float Hori2 { get => Hori; set => Hori = value; }

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
            Hori1 = joystick.Horizontal;
            Verti = joystick.Vertical;
        }
        else
        {
            Hori1 = Input.GetAxisRaw("Horizontal");
            Verti = Input.GetAxisRaw("Vertical");
        }
    }

    private void HandlePlaneRotation()
    {
        float horizontalRotation = Hori1 * MaxHoriRotation;
        float verticalRotation = -Verti * MaxVertiRotation;


        transform.rotation = Quaternion.Lerp(transform.rotation, new Quaternion(-verticalRotation, Hori1 * 0.1f, -horizontalRotation, transform.rotation.w), Time.deltaTime * rotationSmoothnees);

    }

    private void HandlePlaneMove()
    {
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, ForwardSpeed * ForwardSpeedMultiplier * Time.deltaTime);

        float xVelocity = Hori1 * SpeedMultiplier * HorizontalSpeed * Time.deltaTime;
        float yVelocity = -Verti * SpeedMultiplier * verticalSpeed * Time.deltaTime;


        rb.velocity = Vector3.Lerp(rb.velocity, new Vector3(xVelocity, yVelocity, rb.velocity.z), Time.deltaTime * Smoothness);
    }

}
