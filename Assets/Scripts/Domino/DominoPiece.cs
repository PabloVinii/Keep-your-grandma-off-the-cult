using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominoPiece : MonoBehaviour
{
    public DominoPieceData dominoData;
    public int topValue;
    public int bottomValue;

    void Update()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = dominoData.sprite;
        topValue = dominoData.topValue;
        bottomValue = dominoData.bottomValue;

    }

}
