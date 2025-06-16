using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerCarry carry = other.GetComponent<PlayerCarry>();
            if (carry != null)
            {
                Piece piece = GetComponentInParent<Piece>();
                carry.SetNearbyPiece(piece);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerCarry carry = other.GetComponent<PlayerCarry>();
            if (carry != null)
            {
                Piece piece = GetComponentInParent<Piece>();
                carry.ClearNearbyPiece(piece);
            }
        }
    }
}
