using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DominoUI : MonoBehaviour
{
    public GameObject piecePrefab;
    public Transform piecesParent;
    
    public void UpdateUI(List<DominoPiece> playerPieces)
    {
        // Destruir as peças existentes na UI
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        // Instanciar novas peças para cada peça do jogador
        foreach (DominoPiece piece in playerPieces)
        {
            GameObject newPiece = Instantiate(piecePrefab, transform);

            DominoPieceUI dominoPiece = newPiece.GetComponentInChildren<DominoPieceUI>();
            dominoPiece.DominoPiece = piece.dominoData;
        }
    }
}

