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
            }
            else
            {
                itemSprite.sprite = null;
                itemName.text = "";
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
