using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public ItemData referenceItem;
    public InventorySystem inventory;
    public InventoryUi inventoryUi;
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            PickUpItem();
           inventoryUi.UpdateUI();
        }
    }

    public void PickUpItem()
    {
        inventory.Add(referenceItem);
        Destroy(gameObject);
    }
}
