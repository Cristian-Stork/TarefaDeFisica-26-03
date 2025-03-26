using UnityEngine;

public class CannonController : MonoBehaviour
{
    public float rotationSpeed = 5;
    public float minAngle = -10;
    public float maxAngle = 45;

    private float currentAngle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentAngle = transform.localEulerAngles.x;
        if (currentAngle > 180) currentAngle -= 360;
    }

    // Update is called once per frame
    void Update()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        if (scrollInput != 0)
        {
            currentAngle -= scrollInput * rotationSpeed;
            currentAngle = Mathf.Clamp(currentAngle, minAngle, maxAngle);

            transform.localRotation = Quaternion.Euler(currentAngle,0, 0);

            Debug.Log($"Canhão inclinado para {currentAngle} graus");
        }
    }
}
