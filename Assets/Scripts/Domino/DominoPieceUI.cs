using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DominoPieceUI : MonoBehaviour, IPointerClickHandler
{
    public Image dominoSprite;
    private DominoPieceData dominoPiece;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicked on piece: " + dominoPiece.ToString());
    }

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
