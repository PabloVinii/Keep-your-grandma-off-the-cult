using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory item Data")]
public class ItemData : ScriptableObject
{
    public int id;
    public string displayName;
    public Sprite icon;
    public GameObject prefab;
}
