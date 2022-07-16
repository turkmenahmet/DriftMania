using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public static CarController Instance { get; private set; }

    [SerializeField] float carSpeed;
    [SerializeField] float maxSpeed;
    [SerializeField] float steerAngle;
    [SerializeField] float traction;

    float dragAmount = 0.99f;

    public Transform lw, rw;

    Vector3 moveVec;
    Vector3 rotVec;

    private void Awake()
    {
        Instance = this;
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

        // Wheel
        rotVec = Vector3.ClampMagnitude(rotVec, steerAngle);
        lw.localRotation = Quaternion.Euler(rotVec);
        rw.localRotation = Quaternion.Euler(rotVec);
    }

    public void NitroSpeedIncrease()
    {
        carSpeed = 30f;
        Invoke("NitroSpeedDecrease", 2f);
    }
    public void NitroSpeedDecrease()
    {
        carSpeed = 20f;
    }
}
