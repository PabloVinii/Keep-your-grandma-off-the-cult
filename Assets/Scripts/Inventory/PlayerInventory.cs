using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<Item> inventoryItems = new List<Item>();
    public int maxSlots = 7; // Define o número máximo de slots no inventário.

    

    public void AddItem(Item item)
    {
        inventoryItems.Add(item);
        GameObject.FindObjectOfType<InventoryUI>().AddItemSlot(); 
        FindObjectOfType<InventoryUI>().UpdateUI();
    }

    public void RemoveItem(Item item)
    {
        inventoryItems.Remove(item);
        GameObject.FindObjectOfType<InventoryUI>().RemoveItemSlot();
    }

    public bool ContainsItem(Item item)
    {
        return inventoryItems.Contains(item);
    }
}
