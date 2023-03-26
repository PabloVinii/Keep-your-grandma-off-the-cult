using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public Item item;

    public SpriteRenderer spriteRenderer;
    private Collider2D itemCollider;
    [TextArea(4,4)]
    public string description;
    public int id;
    public string itemName;
    public int maxStackSize;
    
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        itemCollider = GetComponent<Collider2D>();

        spriteRenderer.sprite = item.itemSprite;
        description = item.description;
        itemName = item.itemName;
        maxStackSize = item.maxStackSize;
    }

}
