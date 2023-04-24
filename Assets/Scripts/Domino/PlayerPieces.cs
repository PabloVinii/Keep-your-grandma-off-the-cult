using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPieces : MonoBehaviour
{
    public List<DominoPiece> pieces = new List<DominoPiece>();
    public int maxPieces = 7;

    public void AddPiece(DominoPiece piece)
    {
        if (pieces.Count < maxPieces)
        {
            pieces.Add(piece);
            piece.transform.parent = transform;
            piece.gameObject.SetActive(false);
        }
    }

    public void RemovePiece(DominoPiece piece)
    {
        if (pieces.Contains(piece))
        {
            pieces.Remove(piece);
            piece.transform.parent = null;
        }
    }

    public void ResetPieces()
    {
        foreach (var piece in pieces)
        {
            piece.gameObject.SetActive(false);
            piece.transform.parent = null;
            Destroy(piece.gameObject);
        }
        pieces.Clear();
    }
}
