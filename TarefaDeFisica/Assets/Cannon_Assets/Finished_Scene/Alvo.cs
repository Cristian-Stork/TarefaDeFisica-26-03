using UnityEngine;

public class Alvo : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0, moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Limite"))
        {
            moveSpeed = moveSpeed * -1;
        }
    }
}
