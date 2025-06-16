using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PieceSocket : MonoBehaviour
{
    public int expectedID;

    public Transform placementPoint;

    private Piece placedPiece = null;

    private bool playerInside = false;

    private PlayerCarry playerCarry;

    private void OnTriggerEnter(Collider other)

    {

        if (other.CompareTag("Player"))

        {

            playerInside = true;

            playerCarry = other.GetComponent<PlayerCarry>();

            playerCarry?.SetNearbySocket(this);

        }

    }

    private void OnTriggerExit(Collider other)

    {

        playerInside = false;

        if (playerCarry != null)

        {

            playerCarry.ClearNearbySocket(this);

            playerCarry = null;

        }

    }

    public bool TryPlacePiece(Piece piece)

    {

        if (piece.ID == expectedID)

        {

            placedPiece = piece;

            piece.transform.SetParent(placementPoint);

            piece.transform.position = placementPoint.position;

            piece.transform.rotation = placementPoint.rotation;

            Rigidbody rb = piece.GetComponent<Rigidbody>();

            if (rb != null) rb.isKinematic = true;

            Collider col = piece.GetComponent<Collider>();

            if (col != null) col.enabled = false;

            PuzzleManager.Instance.RevisarPuzzleCompleto();

            return true;

        }

        return false;

    }

    public bool IsCorrectlyPlaced()

    {

        return placedPiece != null && placedPiece.ID == expectedID;

    }

    public void ResetSocket()

    {

        if (placedPiece != null)

        {

            placedPiece.ReturnToOriginalPosition();

            placedPiece = null;

        }

    }

    // Ahora devuelve bool, recibe la pieza a colocar



    private void PlacePiece(Piece piece)

    {

        placedPiece = piece;

        piece.transform.SetParent(placementPoint);

        piece.transform.position = placementPoint.position;

        piece.transform.rotation = placementPoint.rotation;

        Rigidbody rb = piece.GetComponent<Rigidbody>();

        if (rb) rb.isKinematic = true;

        Collider col = piece.GetComponent<Collider>();

        if (col) col.enabled = false;

        Debug.Log("Pieza colocada correctamente");

    }

    

}
