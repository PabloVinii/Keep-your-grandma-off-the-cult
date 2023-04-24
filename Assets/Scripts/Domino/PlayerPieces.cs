using System.Collections.Generic;
using UnityEngine;

public class PlayerPieces : MonoBehaviour
{
    public List<DominoPieceData> playerPieces = new List<DominoPieceData>();
    public DominoBoard dominoBoard;
    
    private void Start()
    {
        if (dominoBoard != null)
        {
            // Adiciona as peças do jogador à lista
            playerPieces.AddRange(dominoBoard.playerPieces);
        }
    }

    public void DrawPieceFromDeck()
    {
        // Verifica se o monte está vazio
        if (dominoBoard.boardPieces.Count == 0)
        {
            Debug.Log("O monte está vazio!");
            return;
        }

        // Remove uma peça aleatória do monte
        int randomIndex = Random.Range(0, dominoBoard.boardPieces.Count);
        DominoPieceData drawnPiece = dominoBoard.boardPieces[randomIndex];
        dominoBoard.boardPieces.RemoveAt(randomIndex);

        // Adiciona a peça à mão do jogador
        playerPieces.Add(drawnPiece);

        // Atualiza a UI do jogador
        //gameManager.UpdatePlayerUI(this);
    }
    
    public void PlayPiece(DominoPieceData piece, bool isLeftEnd)
    {
        // Verifica se a peça escolhida é válida
        if (!dominoBoard.IsPlayablePiece(piece, isLeftEnd))
        {
            Debug.Log("Peça inválida!");
            return;
        }

        // Remove a peça da mão do jogador
        playerPieces.Remove(piece);

        // Adiciona a peça à mesa
        dominoBoard.AddPieceToBoard(piece, isLeftEnd);

        // Atualiza a UI do jogador e da mesa
        //gameManager.UpdatePlayerUI(this);
        //gameManager.UpdateBoardUI();
    }

    public void DrawPiece()
    {
        if (dominoBoard.allDominoPieces.Count > 0)
        {
            DominoPieceData drawnPieceData = dominoBoard.allDominoPieces[Random.Range(0, dominoBoard.allDominoPieces.Count)];

            playerPieces.Add(drawnPieceData);
            dominoBoard.allDominoPieces.Remove(drawnPieceData);
        }
    }

}

