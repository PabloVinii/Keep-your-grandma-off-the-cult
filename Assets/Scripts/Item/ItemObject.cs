using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public Item item;

    public SpriteRenderer spriteRenderer;
    private Collider2D itemCollider;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        itemCollider = GetComponent<Collider2D>();

        spriteRenderer.sprite = item.itemSprite;
    }

}
