using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;
public class HoverTipManager : MonoBehaviour
{
    public TextMeshProUGUI tipText;
    public RectTransform tipWindow;
    
    public static Action <string, Vector2> onMouseHover;
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

    private void ShowTip(string tip, Vector2 mousePos)
    {
        tipText.text = tip;
        tipWindow.sizeDelta = new Vector2(tipText.preferredWidth > 200 ? 200 : tipText.preferredWidth, tipText.preferredHeight);
        tipWindow.gameObject.SetActive(true);
        tipWindow.transform.position = new Vector2(mousePos.x + tipWindow.sizeDelta.x * 2, mousePos.y);
    }

    private void HideTip()
    {
        tipText.text = default;
        tipWindow.gameObject.SetActive(false);
    }

}
