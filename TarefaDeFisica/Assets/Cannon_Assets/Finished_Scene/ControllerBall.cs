using UnityEngine;

public class ControllerBall : MonoBehaviour
{
    [SerializeField] int destroyTime;

    Mannager mannager;

    public GameObject explosionEffect;
    public float radius = 5;
    public float explosionForce = 700;

    private void Start()
    {
        mannager = GameObject.Find("Mannager").GetComponent<Mannager>();
        Destroy(gameObject, destroyTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
       GameObject explosion = Instantiate(explosionEffect, transform.position, transform.rotation);

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        Destroy(explosion, 2);

        foreach (Collider nearByObjectCollider in colliders)
        {
            Rigidbody rigidbody = nearByObjectCollider.GetComponent<Rigidbody>();

            if (rigidbody != null && (rigidbody != gameObject.GetComponent<Rigidbody>()))
            {
                rigidbody.AddExplosionForce(explosionForce, transform.position, radius, explosionForce);
            }
        }

        Debug.Log($"Objeto {collision} movido para a cena {collision.gameObject}");

        if (collision.gameObject.CompareTag("Alvo"))
        {
            Destroy(collision.gameObject);
            mannager.vitoria += 1;
        }
    }
}
