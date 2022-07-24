using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacerController : MonoBehaviour
{
    public static RacerController Instance { get; private set; }

    private Vector3 MoveForce;
    public float moveSpeed = 30;
    public float maxSpeed = 15;
    public float drag = 0.98f;
    public float steerAngle = 30;
    public float traction = 1;

    //Vector3 rotVec;
    public Transform FLW, FRW;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        CarFunctions();
    }

    private void CarFunctions()
    {
        // Moving
        MoveForce += transform.forward * moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
        transform.position += MoveForce * Time.deltaTime;

        // Steering
        float steerInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * steerInput * MoveForce.magnitude * steerAngle * Time.deltaTime);

        // Drag and max speed limits
        MoveForce *= drag;
        MoveForce = Vector3.ClampMagnitude(MoveForce, maxSpeed);

        // Traction
        MoveForce = Vector3.Lerp(MoveForce.normalized, transform.forward, traction * Time.deltaTime) * MoveForce.magnitude;

        //// Wheel
        //rotVec = Vector3.ClampMagnitude(rotVec, steerAngle);
        //FLW.localRotation = Quaternion.Euler(rotVec);
        //FRW.localRotation = Quaternion.Euler(rotVec);
    }

    public void NitroSpeedIncrease()
    {
        moveSpeed = 40f;

        Invoke("NitroSpeedDecrease", 2f);
    }
    public void NitroSpeedDecrease()
    {
        moveSpeed = 30f;
    }
}
