using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominoBoard : MonoBehaviour
{
    public List<DominoPieceData> allDominoPieces;
    public List<DominoPieceData> playerPieces;
    public List<DominoPieceData> computerPieces;
    public List<DominoPieceData> boardPieces;

    public DominoPiece leftEndPiece;
    public DominoPiece rightEndPiece;

    public void StartGame()
    {
        ShuffleAllDominoPieces();
        DealPieces();
        StartBoard();
        PlayDomino();
    }

    void ShuffleAllDominoPieces()
    {
        for (int i = 0; i < allDominoPieces.Count; i++)
        {
            int randomIndex = Random.Range(i, allDominoPieces.Count);
            DominoPieceData temp = allDominoPieces[i];
            allDominoPieces[i] = allDominoPieces[randomIndex];
            allDominoPieces[randomIndex] = temp;
        }
    }

    void DealPieces()
    {
        for (int i = 0; i < 7; i++)
        {
            playerPieces.Add(allDominoPieces[i]);
            computerPieces.Add(allDominoPieces[i + 7]);
        }
    }

    void StartBoard()
    {
        int randomIndex = Random.Range(0, playerPieces.Count);
        DominoPieceData startingPiece = playerPieces[randomIndex];
        playerPieces.RemoveAt(randomIndex);
        boardPieces.Add(startingPiece);

        leftEndPiece.dominoData = startingPiece;
        rightEndPiece.dominoData = startingPiece;
    }
    
    void PlayDomino()
    {
        bool isPlayerTurn = true;

        while (playerPieces.Count > 0 && computerPieces.Count > 0)
        {
            if (isPlayerTurn)
            {
                // Player's turn
                DominoPieceData playablePiece = null;
                foreach (DominoPieceData piece in playerPieces)
                {
                    if (piece.topValue == leftEndPiece.dominoData.bottomValue || piece.bottomValue == leftEndPiece.dominoData.bottomValue
                        || piece.topValue == rightEndPiece.dominoData.topValue || piece.bottomValue == rightEndPiece.dominoData.topValue)
                    {
                        playablePiece = piece;
                        break;
                    }
                }

                if (playablePiece != null)
                {
                    // Remove the played piece from player's hand
                    playerPieces.Remove(playablePiece);
                    // Add the played piece to the board
                    boardPieces.Add(playablePiece);
                    // Update the left and right ends of the board
                    if (playablePiece.topValue == leftEndPiece.dominoData.bottomValue)
                    {
                        DominoPiece temp = leftEndPiece;
                        leftEndPiece = Instantiate(Resources.Load<DominoPiece>("Prefabs/DominoPiece"), leftEndPiece.transform.parent);
                        leftEndPiece.transform.position = temp.transform.position;
                        leftEndPiece.transform.rotation = Quaternion.Euler(0, 0, 180);
                        leftEndPiece.dominoData = playablePiece;
                    }
                    else if (playablePiece.bottomValue == leftEndPiece.dominoData.bottomValue)
                    {
                        DominoPiece temp = leftEndPiece;
                        leftEndPiece = Instantiate(Resources.Load<DominoPiece>("Prefabs/DominoPiece"), leftEndPiece.transform.parent);
                        leftEndPiece.transform.position = temp.transform.position;
                        leftEndPiece.transform.rotation = Quaternion.Euler(0, 0, 0);
                        leftEndPiece.dominoData = playablePiece;
                    }
                    else if (playablePiece.topValue == rightEndPiece.dominoData.topValue)
                    {DominoPiece temp = rightEndPiece;
                    rightEndPiece = Instantiate(Resources.Load<DominoPiece>("Prefabs/DominoPiece"), rightEndPiece.transform.parent);
                    rightEndPiece.transform.position = temp.transform.position;
                    rightEndPiece.transform.rotation = Quaternion.Euler(0, 0, 180);
                    rightEndPiece.dominoData = playablePiece;
                }
                else if (playablePiece.bottomValue == rightEndPiece.dominoData.topValue)
                {
                    DominoPiece temp = rightEndPiece;
                    rightEndPiece = Instantiate(Resources.Load<DominoPiece>("Prefabs/DominoPiece"), rightEndPiece.transform.parent);
                    rightEndPiece.transform.position = temp.transform.position;
                    rightEndPiece.transform.rotation = Quaternion.Euler(0, 0, 0);
                    rightEndPiece.dominoData = playablePiece;
                }

                // Switch turns
                isPlayerTurn = !isPlayerTurn;
            }
            else
            {
                // If player has no playable pieces, skip turn
                isPlayerTurn = false;
            }
        }
        else
        {
            // Computer's turn
            // Implement computer's turn logic here

            // Switch turns
            isPlayerTurn = !isPlayerTurn;
        }
    }
}
}