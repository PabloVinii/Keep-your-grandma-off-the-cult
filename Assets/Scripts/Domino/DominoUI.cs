using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DominoUI : MonoBehaviour
{
    // public GameObject piecePrefab;
    // public Transform piecesParent;
    // public List<GameObject> pieceSlots = new List<GameObject>(); // Lista de slots de itens no inventário
    // public PlayerPieces pp;
    // public void UpdateUI(List<DominoPieceData> playerPieces)
    // {
    //     // Destruir as peças existentes na UI
    //     foreach (Transform child in transform)
    //     {
    //         Destroy(child.gameObject);
    //     }

    //     // Instanciar novas peças para cada peça do jogador
    //     foreach (DominoPieceData piece in playerPieces)
    //     {
    //         GameObject newPiece = Instantiate(piecePrefab, transform);
    //         pieceSlots.Add(newPiece);
    //         newPiece.GetComponent<Image>().sprite = piece.sprite;

    //         // Adiciona o componente DominoPieceDataHolder e define o objeto DominoPieceData nele
    //         DominoHolder holder = newPiece.AddComponent<DominoHolder>();
    //         holder.pieceData = piece;
    //     }
    // }

    // public void OnPieceClick(GameObject pieceObj)
    // {
    //     Debug.Log("perto");
    // //     DominoHolder holder = pieceObj.GetComponent<DominoHolder>();

    // //     if (holder != null)
    // //     {
            
    // //         DominoPieceData piece = holder.pieceData;
    // //         pp.PlayPiece(piece, true);
    // //     }
    // }

}

