using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("wheels collider")]
    public WheelCollider frontLeftWheelCollider;
    public WheelCollider frontRightWheelCollider;
    public WheelCollider BackLeftWheelCollider;
    public WheelCollider BackRightWheelCollider;

    [Header("wheels Transform")]
    public Transform frontLeftWheelTransform;
    public Transform frontRightWheelTransform;
    public Transform BackLeftWheelTransform;
    public Transform BackRightWheelTransform;

    [Header("car Engine")]
    public float accelerationForce = 300f;
    public float breakingForce = 5000f;
    private float presentBreakForce = 0f;
    private float presentAcceleration = 0f;

    [Header("car Steering")]
    public float wheelsTorque = 35f;
    private float presentTurnAngle = 0f;

    [Header("car sounds")]
    public AudioSource audioSource;
    public AudioClip accelerationSound;
    public AudioClip slowAccelerationSound;
    public AudioClip stopSound;
    public AudioClip HonkSound;

    public Vector3 initialPosition;
    public Quaternion initialRotation;

    public GameObject BreakLight;
    public GameObject headLight;
    private bool headlightOn = false;

    private void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;

    }
    private void Update()
    {
        MoveCar();
        CarSteering();
        ApplyBreaks();
        Honk();
        Headlight();
        Reset();
    }
    private void MoveCar()
    {
        //trontwheeld
        frontLeftWheelCollider.motorTorque = presentAcceleration;
        frontRightWheelCollider.motorTorque = presentAcceleration;
        BackLeftWheelCollider.motorTorque = presentAcceleration;
        BackRightWheelCollider.motorTorque = presentAcceleration;

        presentAcceleration = accelerationForce * Input.GetAxis("Vertical");

        if (presentAcceleration > 0)
        {
            audioSource.PlayOneShot(accelerationSound, 0.2f);
        }
        else if (presentAcceleration < 0)
        {
            audioSource.PlayOneShot(slowAccelerationSound, 0.2f);
        }
        else if (presentAcceleration == 0)
        {
            audioSource.PlayOneShot(stopSound, 0.1f);
        }

    }
    private void CarSteering()
    {
        presentTurnAngle = wheelsTorque * Input.GetAxis("Horizontal");
        frontLeftWheelCollider.steerAngle = presentTurnAngle;
        frontRightWheelCollider.steerAngle = presentTurnAngle;


        steeringWheels(frontLeftWheelCollider, frontLeftWheelTransform);
        steeringWheels(frontRightWheelCollider, frontRightWheelTransform);
        steeringWheels(BackLeftWheelCollider, BackLeftWheelTransform);
        steeringWheels(BackRightWheelCollider, BackRightWheelTransform);

    }
    void steeringWheels(WheelCollider WC, Transform WT)
    {
        Vector3 position;
        Quaternion rotation;

        WC.GetWorldPose(out position, out rotation);

        WT.position = position;
        WT.rotation = rotation;
    }
    public void ApplyBreaks()
    {
        if (Input.GetKey(KeyCode.B))
        {
            presentBreakForce = breakingForce;
            BreakLight.SetActive(true);
        }
        else
        {
            presentBreakForce = 0f;
            BreakLight.SetActive(false);
        }

        frontLeftWheelCollider.brakeTorque = presentBreakForce;
        frontRightWheelCollider.brakeTorque = presentBreakForce;
        BackLeftWheelCollider.brakeTorque = presentBreakForce;
        BackRightWheelCollider.brakeTorque = presentBreakForce;
    }
    void Honk()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            audioSource.PlayOneShot(HonkSound);
        }
    }
    void Headlight()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            headlightOn = !headlightOn; // Toggle the headlight state
        }

        headLight.SetActive(headlightOn);
    }

    private void Reset()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {

            transform.position = initialPosition;
            transform.rotation = initialRotation;

            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
    }
}