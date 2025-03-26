using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private float minX, maxX, minY, maxY, minZ, maxZ;

    [SerializeField] private GameObject bolinha;
    private SceneTransferManager script;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        script = bolinha.GetComponent<SceneTransferManager>();

        for (int i = 0; i < 6; i++)
        {
            Vector3 spawn = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));

            script.itens[i] = Instantiate(prefab, spawn, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
