using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCarry : MonoBehaviour
{
    public Transform carryPoint;

    public Piece carriedPiece { get; private set; }

    private Piece nearbyPiece;
    private PieceSocket nearbySocket;

    private PickupUI pickupUI;

    public bool IsCarrying => carriedPiece != null;

    private Vector3 previousPosition;
    private Quaternion previousRotation;

    void Start()
    {
        pickupUI = GetComponent<PickupUI>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (carriedPiece == null && nearbyPiece != null)
            {
                PickUp(nearbyPiece);
            }
            else if (carriedPiece != null && nearbySocket != null)
            {
                TryPlaceOnSocket();
            }
            else if (carriedPiece != null)
            {
                DropPiece();
            }
        }

        if (Input.GetKeyDown(KeyCode.R) && nearbySocket != null && carriedPiece != null)
        {
            bool placed = nearbySocket.TryPlacePiece(carriedPiece);
            if (placed)
            {
                carriedPiece = null;
            }
            else
            {
                ReturnCarriedPieceToPreviousPosition();
            }
        }
    }

    void PickUp(Piece piece)
    {
        carriedPiece = piece;

        PuzzleManager.Instance?.IniciarTemporizador();

        // Guardar posición y rotación antes de recoger
        previousPosition = piece.transform.position;
        previousRotation = piece.transform.rotation;

        Rigidbody rb = piece.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true;
        }

        Collider col = piece.GetComponent<Collider>();
        if (col != null)
            col.enabled = false;

        piece.transform.SetParent(carryPoint);
        piece.transform.localPosition = Vector3.zero;
        piece.transform.localRotation = Quaternion.identity;

        pickupUI?.HideMessage();
    }

    // Método para regresar la pieza a la posición anterior
    public void ReturnCarriedPieceToPreviousPosition()
    {
        if (carriedPiece == null) return;

        carriedPiece.transform.SetParent(null);
        carriedPiece.transform.position = previousPosition;
        carriedPiece.transform.rotation = previousRotation;

        Rigidbody rb = carriedPiece.GetComponent<Rigidbody>();
        if (rb != null)
            rb.isKinematic = false;

        Collider col = carriedPiece.GetComponent<Collider>();
        if (col != null)
            col.enabled = true;

        carriedPiece = null;
    }

    public void SetNearbySocket(PieceSocket socket)
    {
        nearbySocket = socket;
    }

    public void ClearNearbySocket(PieceSocket socket)
    {
        if (nearbySocket == socket) nearbySocket = null;
    }

    void DropPiece()
    {
        if (carriedPiece == null) return;

        carriedPiece.transform.SetParent(null);

        Rigidbody rb = carriedPiece.GetComponent<Rigidbody>();
        if (rb != null)
            rb.isKinematic = false;

        Collider col = carriedPiece.GetComponent<Collider>();
        if (col != null)
            col.enabled = true;

        carriedPiece = null;
    }

    void TryPlaceOnSocket()
    {
        if (nearbySocket.TryPlacePiece(carriedPiece))
        {
            carriedPiece = null; // colocada correctamente
        }
        else
        {
            DropPiece(); // incorrecta, dejar caer la pieza
        }
    }

    public void SetNearbyPiece(Piece piece)
    {
        nearbyPiece = piece;
        if (carriedPiece == null) pickupUI?.ShowMessage();
    }

    public void ClearNearbyPiece(Piece piece)
    {
        if (nearbyPiece == piece)
        {
            nearbyPiece = null;
            pickupUI?.HideMessage();
        }
    }

    public void PlaceCarriedPiece()
    {
        carriedPiece = null;
    }
}
