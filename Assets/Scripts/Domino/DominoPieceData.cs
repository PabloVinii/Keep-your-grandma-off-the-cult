using UnityEngine;

[CreateAssetMenu(fileName = "New Domino Piece", menuName = "Domino Piece")]
public class DominoPieceData : ScriptableObject
{
    public string namePiece;
    public Sprite sprite;
    public int topValue;
    public int bottomValue;
}
