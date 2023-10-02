using UnityEngine;

public class Drift : MonoBehaviour
{
    public WheelCollider[] rearWheelColliders;
    public float driftTorque = 2000f;
    public float maxSidewaysSlip = 0.2f;
    private bool isDrifting = false;

    private void Update()
    {
        // Check if the "B" key is pressed and held to enable drifting.
        if (Input.GetKey(KeyCode.Space))
        {
            isDrifting = true;
            ApplyDrift(); // Apply drift immediately when "B" is pressed.
        }
        else
        {
            isDrifting = false;
        }
    }

    private void FixedUpdate()
    {
        if (!isDrifting)
        {
            // Reset the sideways friction to its normal value when not drifting.
            foreach (WheelCollider wheelCollider in rearWheelColliders)
            {
                WheelFrictionCurve sidewaysFriction = wheelCollider.sidewaysFriction;
                sidewaysFriction.stiffness = 1.0f; // Set to your normal value
                wheelCollider.sidewaysFriction = sidewaysFriction;
            }
        }
    }

    private void ApplyDrift()
    {
        foreach (WheelCollider wheelCollider in rearWheelColliders)
        {
            // Apply a drift torque to the rear wheels.
            wheelCollider.motorTorque = -driftTorque;

            // Adjust sideways friction to enable drifting.
            WheelFrictionCurve sidewaysFriction = wheelCollider.sidewaysFriction;
            sidewaysFriction.stiffness = maxSidewaysSlip;
            wheelCollider.sidewaysFriction = sidewaysFriction;
        }
    }
}
