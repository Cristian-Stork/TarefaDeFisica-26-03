using UnityEngine;

public class CannonMovememtn : MonoBehaviour
{
    public WheelCollider[] wheels;
    public float motorTorque = 1000;
    public float maxSteerAngle = 30;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveInput = Input.GetAxis("Vertical");
        float steerInput = Input.GetAxis("Horizontal");

        foreach (WheelCollider wheel in wheels)
        {
            wheel.motorTorque = moveInput * motorTorque;
        }

        wheels[0].steerAngle = steerInput * maxSteerAngle;
        wheels[1].steerAngle = steerInput * maxSteerAngle;
    }
}
