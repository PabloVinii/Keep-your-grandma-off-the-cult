using System.Collections.Generic;
using UnityEngine;

public class DominoBoard : MonoBehaviour
{
    public GameObject dominoPiecePrefab;
    public Transform playerHand;
    public Transform enemyHand;
    public Transform boardLocal;
    public DominoUI dominoUi;

    [SerializeField] private List<DominoPiece> boardPieces = new List<DominoPiece>();
    [SerializeField] private List<DominoPiece> playerPieces = new List<DominoPiece>();
    [SerializeField] private List<DominoPiece> computerPieces = new List<DominoPiece>();
    [SerializeField] private DominoPiece lastPiecePlayed;

    public List<DominoPieceData> pieceDataList = new List<DominoPieceData>();

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

    private bool IsMoveValid(DominoPiece piece)
    {
        // Se for a primeira jogada, qualquer peça pode ser jogada
        if (lastPiecePlayed == null)
        {
            return true;
        }

        // Verifica se a peça pode ser jogada no lado direito da mesa
        if (piece.dominoData.topValue == lastPiecePlayed.dominoData.topValue)
        {
            return true;
        }

        // Verifica se a peça pode ser jogada no lado esquerdo da mesa
        if (piece.dominoData.bottomValue == lastPiecePlayed.dominoData.topValue)
        {
            return true;
        }

        // Se não for possível jogar a peça em nenhum dos lados, retorna false
        return false;
    }

    public void PlayPiece(DominoPiece piece, bool playRight)
    {
        if (!IsMoveValid(piece))
        {
            Debug.Log("Jogada inválida!");
            return;
        }

        if (playRight)
        {
            // Se a peça será jogada no lado direito da mesa, atualiza a referência da última peça jogada
            lastPiecePlayed = piece;
        }
        else
        {
            // Se a peça será jogada no lado esquerdo da mesa, atualiza a referência da última peça jogada
            lastPiecePlayed = piece.Invert();
        }

        // Remove a peça da lista do jogador e adiciona na mesa
        playerPieces.Remove(piece);
        boardPieces.Add(piece);

        // Atualiza a UI
        lastPiecePlayed = piece;
        dominoUi.UpdateUI(playerPieces);
    }

    public bool TryPlayPiece(DominoPiece pieceData)
    {
        if (boardPieces.Count == 0)
        {
            // First piece played on the board
            DominoPiece newPiece = Instantiate(dominoPiecePrefab, boardLocal).GetComponent<DominoPiece>();
            newPiece.topValue = pieceData.topValue;
            newPiece.bottomValue = pieceData.bottomValue;
            boardPieces.Add(newPiece);
            lastPiecePlayed = pieceData;
            return true;
        }

        bool canPlay = false;
        foreach (DominoPiece piece in playerPieces)
        {
            if (piece.CanBePlayed(lastPiecePlayed))
            {
                canPlay = true;
                break;
            }
        }

        if (canPlay)
        {
            // Player has a piece that can be played
            DominoPiece newPiece = Instantiate(dominoPiecePrefab, boardLocal).GetComponent<DominoPiece>();
            newPiece.topValue = pieceData.topValue;
            newPiece.bottomValue = pieceData.bottomValue;
            boardPieces.Add(newPiece);
            lastPiecePlayed = pieceData;
            return true;
        }

        // Player cannot play, so the computer plays
        foreach (DominoPiece piece in computerPieces)
        {
            if (piece.CanBePlayed(lastPiecePlayed))
            {
                // Computer plays this piece
                computerPieces.Remove(piece);
                boardPieces.Add(piece);
                piece.transform.SetParent(boardLocal);
                piece.transform.localPosition = Vector3.zero;
                piece.transform.localRotation = Quaternion.identity;
                lastPiecePlayed = piece;
                return true;
            }
        }

        return false;
    }

    public void AddPieceToPlayer(DominoPiece piece)
    {
        playerPieces.Add(piece);
    }
}

