using UnityEngine;

public class ControllerBall : MonoBehaviour
{
    [SerializeField] int destroyTime;

    Mannager mannager;

    private void Start()
    {
        mannager = GameObject.Find("Mannager").GetComponent<Mannager>();
    }

    private void Update()
    {
        Destroy(gameObject, destroyTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Objeto {collision} movido para a cena {collision.gameObject}");

        if (collision.gameObject.CompareTag("Alvo"))
        {
            Destroy(collision.gameObject);
            mannager.vitoria += 1;
        }
    }
}
