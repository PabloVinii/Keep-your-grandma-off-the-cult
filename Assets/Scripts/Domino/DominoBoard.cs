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


    public void StartGame()
    {
        // Find the highest piece in the player's hand
        DominoPiece highestPlayerPiece = playerPieces[0];
        foreach (DominoPiece piece in playerPieces)
        {
            if (piece.topValue + piece.bottomValue > highestPlayerPiece.topValue + highestPlayerPiece.bottomValue)
            {
                highestPlayerPiece = piece;
            }
        }

        // Find the highest piece in the computer's hand
        DominoPiece highestComputerPiece = computerPieces[0];
        foreach (DominoPiece piece in computerPieces)
        {
            if (piece.topValue + piece.bottomValue > highestComputerPiece.topValue + highestComputerPiece.bottomValue)
            {
                highestComputerPiece = piece;
            }
        }

        // Check who has the highest piece
        if (highestPlayerPiece.topValue + highestPlayerPiece.bottomValue >= highestComputerPiece.topValue + highestComputerPiece.bottomValue)
        {
            Debug.Log("Player starts the game!" + highestPlayerPiece.dominoData.namePiece);
            PlayerTurn();
        }
        else
        {
            Debug.Log("Computer starts the game! " + " " + highestComputerPiece.dominoData.namePiece);
            ComputerTurn();
        }
    }

    private List<DominoPiece> GetPlayablePieces()
    {
        List<DominoPiece> playablePieces = new List<DominoPiece>();

        // Check if any player's piece can be played
        int leftValue = boardPieces[0].bottomValue;
        foreach (DominoPiece piece in computerPieces)
        {
            if (piece.topValue == leftValue || piece.bottomValue == leftValue)
            {
                playablePieces.Add(piece);
            }
        }

        // Check if any player's piece can be played on the right side of the board
        int rightValue = boardPieces[boardPieces.Count - 1].topValue;
        foreach (DominoPiece piece in computerPieces)
        {
            if (piece.topValue == rightValue || piece.bottomValue == rightValue)
            {
                playablePieces.Add(piece);
            }
        }

        return playablePieces;
    }


    void PlayerTurn()
    {
        // TODO: implement player's turn
    }

    private void ComputerTurn()
{
    List<DominoPiece> playablePieces = GetPlayablePieces();

    // Check if the computer has a playable piece
    if (playablePieces.Count > 0)
    {
        // Computer has playable piece, select a random one
        DominoPiece pieceToPlay = playablePieces[UnityEngine.Random.Range(0, playablePieces.Count)];

        // Remove the piece from the computer's hand and place it on the board
        computerPieces.Remove(pieceToPlay);
        if (boardPieces.Count == 0)
        {
            // First piece, add to the center of the board
            boardPieces.Add(pieceToPlay);
        }
        else
        {
            // Check which side to add the piece to
            int leftValue = boardPieces[0].bottomValue;
            int rightValue = boardPieces[boardPieces.Count - 1].topValue;
            if (pieceToPlay.topValue == leftValue || pieceToPlay.bottomValue == leftValue)
            {
                // Add to the left side of the board
                boardPieces.Insert(0, pieceToPlay);
            }
            else
            {
                // Add to the right side of the board
                boardPieces.Add(pieceToPlay);
            }
        }
    }
    else
    {
        // Computer has no playable piece, draw a new piece from the boneyard
        if (boardPieces.Count > 0)
        {
            DominoPiece newPiece = boardPieces[0];
            boardPieces.RemoveAt(0);
            computerPieces.Add(newPiece);
        }
    }

    // Check if the computer won the game
    // if (computerPieces.Count == 0)
    // {
    //     gameOver = true;
    //     winner = "Computer";
    // }
}



}

