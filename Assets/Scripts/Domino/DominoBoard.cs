using System.Collections.Generic;
using UnityEngine;

public class DominoBoard : MonoBehaviour
{
    public List<DominoPieceData> pieceDataList = new List<DominoPieceData>();

    public GameObject dominoPiecePrefab;
    public Transform playerHand;
    public Transform enemyHand;
    public Transform boardLocal;
    public DominoUI dominoUi;

    [SerializeField] private List<DominoPiece> boardPieces = new List<DominoPiece>();
    [SerializeField] private List<DominoPiece> playerPieces = new List<DominoPiece>();
    [SerializeField] private List<DominoPiece> computerPieces = new List<DominoPiece>();

    void Start()
    {
        ShufflePieces();
        DistributePieces();
    }

    void ShufflePieces()
    {
        // Shuffle the pieceDataList
        for (int i = 0; i < pieceDataList.Count; i++)
        {
            DominoPieceData temp = pieceDataList[i];
            int randomIndex = Random.Range(i, pieceDataList.Count);
            pieceDataList[i] = pieceDataList[randomIndex];
            pieceDataList[randomIndex] = temp;
        }
    }

    void DistributePieces()
    {
        playerPieces.Clear();
        // Give the first 7 pieces to the player
        for (int i = 0; i < 7; i++)
        {
            DominoPieceData data = pieceDataList[i];
            DominoPiece newPiece = Instantiate(dominoPiecePrefab, playerHand).GetComponent<DominoPiece>();
            newPiece.dominoData = data;
            playerPieces.Add(newPiece);
            pieceDataList.Remove(data);
            dominoUi.UpdateUI(playerPieces);
        }

        // Give the next 7 pieces to the computer
        for (int i = 0; i < 7; i++)
        {
            DominoPieceData data = pieceDataList[i];
            DominoPiece newPiece = Instantiate(dominoPiecePrefab, enemyHand).GetComponent<DominoPiece>();
            newPiece.dominoData = data;
            computerPieces.Add(newPiece);
            pieceDataList.Remove(data);
        }

        // Put the rest of the pieces on the board
        for (int i = 0; i < pieceDataList.Count; i++)
        {
            DominoPieceData data = pieceDataList[i];
            DominoPiece newPiece = Instantiate(dominoPiecePrefab, boardLocal).GetComponent<DominoPiece>();
            newPiece.dominoData = data;
            boardPieces.Add(newPiece);
        }
    }
}

