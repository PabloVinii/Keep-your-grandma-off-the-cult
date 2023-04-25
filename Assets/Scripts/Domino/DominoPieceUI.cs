using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DominoPieceUI : MonoBehaviour
{
    public Image dominoSprite;
    private DominoPieceData dominoPiece;

    public DominoPieceData DominoPiece
    {
        get { return dominoPiece; }
        set
        {
            dominoPiece = value;
            if (dominoPiece != null)
            {
                dominoSprite.sprite = dominoPiece.sprite;
            }
            else
            {
                dominoSprite.sprite = null;
            }
        }
    }

}
