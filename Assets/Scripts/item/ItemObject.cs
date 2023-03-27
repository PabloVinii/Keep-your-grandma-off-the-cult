using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public ItemData referenceItem;
    public InventorySystem inventory;
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            PickUpItem();
        }
    }

    public void PickUpItem()
    {
        inventory.Add(referenceItem);
        Destroy(gameObject);
    }
}
