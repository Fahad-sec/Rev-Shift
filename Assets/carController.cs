using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class carController : MonoBehaviour
{
    public WheelCollider frontLeft, frontRight, rearLeft, rearRight;
    public float motorForce = 1500f;
    public float maxSteerAngle = 30f;
    public float brakeForce = 3000f;

    public float moveInput;
    public float steerInput;
    public bool isBraking;


    public void OnMove(InputValue value)
    {
        Vector2 inputVec = value.Get<Vector2>();
        steerInput = inputVec.x;
        moveInput = inputVec.y;
    }

    public void OnBrake(InputValue value)
    {
        isBraking = value.isPressed;
    }
    void FixedUpdate()
    {

        rearLeft.motorTorque = moveInput *  motorForce;
        rearRight.motorTorque = moveInput * motorForce;

        frontLeft.steerAngle = steerInput * maxSteerAngle;
        frontRight.steerAngle = steerInput * maxSteerAngle;

        if (isBraking) ApplyBraking(); else ReleaseBraking();


    }

    void ApplyBraking()
    {
        frontLeft.brakeTorque = frontRight.brakeTorque = brakeForce;
        rearLeft.brakeTorque = rearRight.brakeTorque = brakeForce;
    }

    void ReleaseBraking()
    {
        frontLeft.brakeTorque = frontRight.brakeTorque = 0f;
        rearLeft.brakeTorque = rearRight.brakeTorque   = 0f;
    }

  
}
