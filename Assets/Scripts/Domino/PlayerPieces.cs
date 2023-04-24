using System.Collections.Generic;
using UnityEngine;

public class PlayerPieces : MonoBehaviour
{
    [SerializeField] private List<DominoPiece> playerPieces = new List<DominoPiece>();

    public void AddPiece(DominoPiece piece)
    {
        playerPieces.Add(piece);
    }

    public void RemovePiece(DominoPiece piece)
    {
        playerPieces.Remove(piece);
    }

    public void ResetPieces()
    {
        foreach (DominoPiece piece in playerPieces)
        {
            piece.transform.SetParent(transform);
            piece.transform.localPosition = Vector3.zero;
            piece.gameObject.SetActive(true);
        }
        playerPieces.Clear();
    }

    public void UpdatePlayerPieces(List<DominoPiece> pieces)
    {
        playerPieces = pieces;
    }
}
