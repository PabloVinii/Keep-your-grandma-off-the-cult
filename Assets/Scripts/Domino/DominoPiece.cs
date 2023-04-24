using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominoPiece : MonoBehaviour
{
    public DominoPieceData dominoData;
    public int topValue;
    public int bottomValue;
    public Sprite sprite;

    public void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = dominoData.sprite;
        sprite = dominoData.sprite;
        topValue = dominoData.topValue;
        bottomValue = dominoData.bottomValue;

    }

}
