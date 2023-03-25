using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public int id;
    public string itemName;
    public Sprite itemSprite;
    [TextArea(4,4)]
    public string description;
    public int maxStackSize;
}
