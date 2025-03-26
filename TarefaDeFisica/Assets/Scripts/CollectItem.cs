using UnityEngine;

public class CollectItem : MonoBehaviour
{
    [SerializeField] private int itensCollected;

    [SerializeField] private GameObject youWin;
    [SerializeField] private GameObject youLose;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (itensCollected == 6)
        {
            Time.timeScale = 0;
            youWin.SetActive(true);
        }

        if (transform.position.y <= -5)
        {
            Time.timeScale = 0;
            youLose.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            Destroy(collision.gameObject);
            itensCollected++;
        }
    }
}
