using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] float carSpeed;
    [SerializeField] float maxSpeed;
    [SerializeField] float steerAngle;
    [SerializeField] float traction;

    float dragAmount = 0.99f;

    public Transform lw, rw;

    Vector3 moveVec;
    Vector3 rotVec;

    void Start()
    {
        
    }

    void Update()
    {
        // Moving
        moveVec += transform.forward * carSpeed * Time.deltaTime;
        transform.position += moveVec * Time.deltaTime;

        rotVec += new Vector3(0, Input.GetAxis("Horizontal"), 0);

        // Rotate
        transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * steerAngle * Time.deltaTime * moveVec.magnitude);

        // Steering
        moveVec *= dragAmount;
        moveVec = Vector3.ClampMagnitude(moveVec, maxSpeed);
        moveVec = Vector3.Lerp(moveVec.normalized, transform.forward, traction * Time.deltaTime) * moveVec.magnitude;

        rotVec = Vector3.ClampMagnitude(rotVec, steerAngle);
        lw.localRotation = Quaternion.Euler(rotVec);
        rw.localRotation = Quaternion.Euler(rotVec);
    }
}