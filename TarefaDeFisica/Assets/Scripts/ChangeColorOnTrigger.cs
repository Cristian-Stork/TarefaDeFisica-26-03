using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorOnTrigger : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            Color ramdomlySelectedColorWithAlpha = GetRandomColorWithAlpha();

            GetComponent<Renderer>().material.color = ramdomlySelectedColorWithAlpha;
        }
    }

    private Color GetRandomColorWithAlpha()
    {
        return new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 0.25f);
    }
}
