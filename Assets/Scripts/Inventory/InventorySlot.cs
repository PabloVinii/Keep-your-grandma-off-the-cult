using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    public Image itemSprite;
    public TextMeshProUGUI stackCount;
    public TextMeshProUGUI itemName;
    public int itemId;

    private ItemData itemData;

    public ItemData ItemData
    {
        get { return itemData; }
        set
        {
            itemData = value;
            if (itemData != null)
            {
                itemSprite.sprite = itemData.icon;
                itemName.text = itemData.displayName;
                itemId = itemData.id;
            }
            else
            {
                itemSprite.sprite = null;
                itemName.text = "";
                itemId = 0;
            }
        }
    }

    public int ItemCount
    {
        set
        {
            stackCount.text = value > 1 ? "x" + value : "";
        }
    }
}
