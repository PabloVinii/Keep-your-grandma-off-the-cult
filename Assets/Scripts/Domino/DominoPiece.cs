using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominoPiece : MonoBehaviour
{
    public DominoPieceData dominoData;

    void Awake()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = dominoData.sprite;
    }

}
