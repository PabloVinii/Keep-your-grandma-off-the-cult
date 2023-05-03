using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;
public class HoverTipManager : MonoBehaviour
{
    public TextMeshProUGUI tipTitle;
    public TextMeshProUGUI tipDescription;
    public RectTransform tipWindow;
    
    public static Action <ItemData,Vector2> onMouseHover;
    public static Action onMouseLoseFocus;

    // Start is called before the first frame update
    void Start()
    {
        HideTip();
    }

    private void OnEnable()
    {
        onMouseHover += ShowTip;
        onMouseLoseFocus += HideTip;
    }

    private void OnDisable() 
    {
        onMouseHover -= ShowTip;
        onMouseLoseFocus -= HideTip;
    }

    private void ShowTip(ItemData item, Vector2 mousePos)
    {
        tipTitle.text = item.displayName;
        tipDescription.text = item.description;
        tipWindow.gameObject.SetActive(true);
        tipWindow.position = mousePos + new Vector2(tipWindow.rect.width, 0f);
    }

    private void HideTip()
    {
        tipTitle.text = default;
        tipDescription.text = default;
        tipWindow.gameObject.SetActive(false);
    }

}
