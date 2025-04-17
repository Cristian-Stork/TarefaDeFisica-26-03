using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchProjectileFinished : MonoBehaviour
{
    public GameObject projectile;
    public float launchVelocity = 700f;

    public float recoilForce = 300f;
    public Rigidbody cannonRb;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject ball = Instantiate(projectile,
            transform.position, transform.rotation);

            ball.GetComponent<Rigidbody>().AddRelativeForce(new
            Vector3(0, launchVelocity, 0));

            if (cannonRb != null)
            {
                cannonRb.AddRelativeForce(new Vector3(0, 0, recoilForce), ForceMode.Impulse);
                cannonRb.AddForce(-transform.up * recoilForce, ForceMode.Impulse);
            }
        }
    }
}
