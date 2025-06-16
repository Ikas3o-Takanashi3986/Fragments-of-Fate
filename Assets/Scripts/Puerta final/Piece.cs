using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public int ID;

    private Vector3 originalPosition;
    private Quaternion originalRotation;

    void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    // Devuelve la posición original (para cuando se coloca mal)
    public void ReturnToOriginalPosition()
    {
        transform.position = originalPosition;
        transform.rotation = originalRotation;

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
            rb.velocity = rb.angularVelocity = Vector3.zero;

        transform.SetParent(null);

        Collider col = GetComponent<Collider>();
        if (col != null) col.enabled = true;
    }
}
