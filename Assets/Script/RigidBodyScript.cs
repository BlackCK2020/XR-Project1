using UnityEngine;

public class RigidBodyScript : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {

            Debug.LogError("Aucun Rigidbody trouv� sur l'objet !", gameObject);
            return;
        }
        rb.useGravity = false;
        rb.isKinematic = true;
    }

    public void ActivateRigidbody()
    {
        if (rb != null)
        {
            rb.useGravity = true;
            rb.isKinematic = false;
            MeshCollider meshCollider = gameObject.AddComponent<MeshCollider>();
            meshCollider.convex = true;
            Debug.Log($"Chute activ�e pour {gameObject.name}");
        }
    }
}