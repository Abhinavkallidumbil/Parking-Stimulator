using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newMovement : MonoBehaviour
{
    public WheelCollider RL;
    public WheelCollider RR;
    public WheelCollider FL;
    public WheelCollider FR;

    public Transform RLT;
    public Transform RRT;
    public Transform FLT;
    public Transform FRT;

    float PresentAcceleration = 0f;

    private void Update()
    {
        move();
        CarSteering();
    }

    void move()
    {
        RL.motorTorque = PresentAcceleration;
        RR.motorTorque = PresentAcceleration;
        FL.motorTorque = PresentAcceleration;
        FR.motorTorque = PresentAcceleration;

        PresentAcceleration = 3000 * Input.GetAxis("Vertical");
    }
    void steeringWheels(WheelCollider WC, Transform WT)
    {
        Vector3 position;
        Quaternion rotation;

        WC.GetWorldPose(out position, out rotation);

        WT.position = position;
        WT.rotation = rotation;
    }
    private void CarSteering()
    {

        steeringWheels(FL, FLT);
        steeringWheels(FR, FRT);
        steeringWheels(RL, RLT);
        steeringWheels(RR, RRT);

    }
}
