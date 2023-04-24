using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominoBoard : MonoBehaviour
{
    public List<DominoPieceData> allDominoPieces;
    public List<DominoPieceData> playerPieces;
    public List<DominoPieceData> computerPieces;
    public List<DominoPieceData> boardPieces;
    public PlayerPieces player;
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
                    if (IsPlayablePiece(piece, true) || IsPlayablePiece(piece, false))
                    {
                        playablePiece = piece;
                        break;
                    }
                }

                if (playablePiece != null)
                {
                    AddPieceToBoard(playablePiece, true);
                    isPlayerTurn = false;
                }
                else
                {
                    // no playable pieces, draw a new piece from the boneyard
                    player.DrawPiece();
                }
            }
            else
            {
                // Computer's turn
                // code for computer's turn here
                isPlayerTurn = true;
            }
        }
    }

    
    public bool IsPlayablePiece(DominoPieceData piece, bool isLeftEnd)
    {
        return piece.topValue == leftEndPiece.dominoData.bottomValue 
            || piece.bottomValue == leftEndPiece.dominoData.bottomValue
            || piece.topValue == rightEndPiece.dominoData.topValue 
            || piece.bottomValue == rightEndPiece.dominoData.topValue;
    }

    public void AddPieceToBoard(DominoPieceData piece, bool addToLeftEnd)
    {
        if (addToLeftEnd)
        {
            // adiciona peça ao lado esquerdo
            playerPieces.Remove(piece);
            boardPieces.Add(piece);
            DominoPiece temp = leftEndPiece;
            leftEndPiece = Instantiate(Resources.Load<DominoPiece>("Prefabs/DominoPiece"), leftEndPiece.transform.parent);
            leftEndPiece.transform.position = temp.transform.position;
            leftEndPiece.transform.rotation = Quaternion.Euler(0, 0, 180);
            leftEndPiece.dominoData = piece;
        }
        else
        {
            // adiciona peça ao lado direito
            playerPieces.Remove(piece);
            boardPieces.Add(piece);
            DominoPiece temp = rightEndPiece;
            rightEndPiece = Instantiate(Resources.Load<DominoPiece>("Prefabs/DominoPiece"), rightEndPiece.transform.parent);
            rightEndPiece.transform.position = temp.transform.position;
            rightEndPiece.transform.rotation = Quaternion.Euler(0, 0, 0);
            rightEndPiece.dominoData = piece;
        }
    }

    
}