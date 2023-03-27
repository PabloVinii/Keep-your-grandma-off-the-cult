using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public Dictionary<ItemData, InventoryItem> itemDictionary;
    public List<InventoryItem> inventory;
    private InventoryUi inventoryUi;

    private void Awake() {
        inventoryUi = FindObjectOfType<InventoryUi>();
        inventory = new List<InventoryItem>();
        itemDictionary = new Dictionary<ItemData, InventoryItem>();
    }

    public InventoryItem Get(ItemData referenceData)
    {
        if (itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            return value;
        }
        return null;
    }
    
    public void Add(ItemData referenceData)
    {
        if (itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            value.AddToStack();
            inventoryUi.UpdateUI();
        }
        else
        {
            InventoryItem newItem = new InventoryItem(referenceData);
            inventory.Add(newItem);
            inventoryUi.UpdateUI();
            itemDictionary.Add(referenceData, newItem);
        }
    }

    public void Remove(ItemData referenceData, int amount=1)
    {
        if (itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            value.RemoveFromStack(amount);

            if (value.stackSize == 0)
            {
                inventory.Remove(value);
                itemDictionary.Remove(referenceData);
            }

            inventoryUi.UpdateUI();
        }
    }
}

