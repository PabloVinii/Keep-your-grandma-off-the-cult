using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominoBoard : MonoBehaviour
{
    public List<DominoPieceData> PieceDataList;
    public List<DominoPiece> piecesOnBoard;

    public GameObject playerPiecePrefab;
    public Transform playerHand;

    void Start()
    {
        DistributePieces();
        SortPieces();
    }

    void DistributePieces()
    {
        for (int i = 0; i < 7; i++)
        {
            GameObject piece = Instantiate(playerPiecePrefab, playerHand);
            int randomIndex = Random.Range(0, PieceDataList.Count);
            DominoPieceData randomPieceData = PieceDataList[randomIndex];
            piece.GetComponent<DominoPiece>().dominoData = randomPieceData;
            PieceDataList.RemoveAt(randomIndex);
        }
    }

    void SortPieces()
    {
        // Implementar algoritmo de ordenação das peças
    }
}
