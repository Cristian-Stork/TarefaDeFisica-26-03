using UnityEngine;

public class PushCannon : MonoBehaviour
{
    public float moveSpeed = 5;
    public float turnSpeed = 10;
    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        float moveInput = Input.GetAxis("Vertical");
        float turnInput = Input.GetAxis("Horizontal");

        Vector3 moveDirection = transform.forward * moveInput * moveSpeed * Time.fixedDeltaTime;

        rb.MovePosition(rb.position + moveDirection);

        rb.MoveRotation(rb.rotation * Quaternion.Euler(Vector3.up * turnInput * turnSpeed * Time.fixedDeltaTime));
    }
}
