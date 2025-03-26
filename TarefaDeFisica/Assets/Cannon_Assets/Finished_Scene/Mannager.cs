using UnityEngine;

public class Mannager : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    public int vitoria = 0;

    // Update is called once per frame
    void Update()
    {
        if (vitoria >= 3)
        {
            Time.timeScale = 0;

            panel.SetActive(true);
        }
    }
}
