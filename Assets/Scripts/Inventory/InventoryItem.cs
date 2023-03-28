using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class InventoryItem
{
    public ItemData data;
    public int stackSize;

    public InventoryItem(ItemData source)
    {
        data = source;
        AddToStack();
    }

    public void AddToStack()
    {
        stackSize++;
    }

    public void RemoveFromStack(int amount)
    {
        stackSize-= amount;
    }

}
