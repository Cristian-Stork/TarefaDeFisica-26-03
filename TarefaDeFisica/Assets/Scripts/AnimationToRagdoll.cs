using System.Collections;
using UnityEngine;

public class AnimationToRagdoll : MonoBehaviour
{
    [SerializeField] Collider myCollider;
    [SerializeField] private float respawnTime = 30f;
    Rigidbody[] rigidbodies;
    bool bIsRagdoll = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbodies = GetComponentsInChildren<Rigidbody>();
        ToggleRagdoll(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Colisão detectada com: " + $"{collision.gameObject.name}" + $" - Tag: {collision.gameObject.tag} - bIsRagdoll: " + $"{bIsRagdoll}");

        if (collision.gameObject.CompareTag("Projectile") && !bIsRagdoll)
        {
            Debug.Log("Colidiu com projétil");
            ToggleRagdoll(false);
            StartCoroutine(GetBackUp());
        }
    }

    private IEnumerator GetBackUp()
    {
        yield return new WaitForSeconds(respawnTime);
        ToggleRagdoll(true);
    }

    private void ToggleRagdoll(bool bIsAnimating)
    {
        bIsRagdoll = !bIsAnimating;
        myCollider.enabled = bIsAnimating;

        foreach (Rigidbody ragdollBone in rigidbodies)
        {
            Debug.Log($"{ragdollBone.name} is Kinematic = " + $"{ragdollBone.isKinematic}");
        }

        foreach (Rigidbody ragdollBone in rigidbodies)
        {
            ragdollBone.isKinematic = bIsAnimating;
        }

        GetComponent<Animator>().enabled = bIsAnimating;
        if (bIsAnimating)
        {
            RandomAnimation();
        }
    }

    private void RandomAnimation()
    {
        int randomNum = Random.Range(0, 2);
        Debug.Log(randomNum);
        Animator animator = GetComponent<Animator>();

        if (randomNum == 0)
        {
            animator.SetTrigger("Walk");
        }

        else
        {
            animator.SetTrigger("Idle");
        }
    }
}
