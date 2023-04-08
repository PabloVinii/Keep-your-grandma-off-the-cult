using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string tipTitle;
    public string tipDescription;
    private float timeToWait = 0.5f;
    public InventorySystem inventory;

    private void Awake() {
        inventory = FindObjectOfType<InventorySystem>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        StopAllCoroutines();
        StartCoroutine(StartTimer());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopAllCoroutines();
        HoverTipManager.onMouseLoseFocus();
    }

    private IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(timeToWait);

        if (inventory.itemDictionary.TryGetValue(GetItemDataById(1), out InventoryItem inventoryItem))
        {
            HoverTipManager.onMouseHover(inventoryItem.data, Input.mousePosition);
        }
    }

    private ItemData GetItemDataById(int id)
    {
        foreach (ItemData item in inventory.itemDictionary.Keys)
        {
            if (item.id == id)
            {
                return item;
            }
        }

        return null;
    }

}
