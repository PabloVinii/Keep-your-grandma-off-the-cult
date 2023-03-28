using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory item Data")]
public class ItemData : ScriptableObject
{
    public int id;
    public int questId;
    public string displayName;
    [TextArea (4,4)]
    public string description;
    public Sprite icon;
    public GameObject prefab;
}
