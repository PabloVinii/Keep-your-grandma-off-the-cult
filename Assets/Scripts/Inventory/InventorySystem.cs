using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public Dictionary<ItemData, InventoryItem> itemDictionary;
    public List<InventoryItem> inventory;

    private void Awake() {
        
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
        }
        else
        {
            InventoryItem newItem = new InventoryItem(referenceData);
            inventory.Add(newItem);
            itemDictionary.Add(referenceData, newItem);
        }
    }

    public void Remove(ItemData referenceData)
    {
        if (itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            value.RemoveFromStack();

            if (value.stackSize == 0)
            {
                inventory.Remove(value);
                itemDictionary.Remove(referenceData);
            }
        }
    }
}

