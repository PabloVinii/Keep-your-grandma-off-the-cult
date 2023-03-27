using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUi : MonoBehaviour
{
    public GameObject inventoryPanel; // Referência para o objeto de UI que contém a lista de itens do inventário
    public GameObject itemSlotPrefab; // Prefab para os slots de itens no inventário
    public List<GameObject> itemSlots = new List<GameObject>(); // Lista de slots de itens no inventário

    [SerializeField] private InventorySystem inventory; // Referência para o inventário do jogador
    private int numSlots = 0; // Número de slots criados

    private void Start()
    {
        inventory = FindObjectOfType<InventorySystem>();

        // Cria os slots de itens no inventário
        UpdateUI();
    }

    // Atualiza a UI do inventário
    public void UpdateUI()
    {
        // Remove todos os slots de itens do inventário
        foreach (GameObject slot in itemSlots)
        {
            Destroy(slot);
        }
        itemSlots.Clear();

        // Cria os slots de itens do inventário com base no número de itens no inventário
        foreach (InventoryItem item in inventory.inventory)
        {
            GameObject newItemSlot = Instantiate(itemSlotPrefab, inventoryPanel.transform);
            itemSlots.Add(newItemSlot);

            // Adiciona os itens do inventário aos slots de itens da UI
            newItemSlot.GetComponentInChildren<Image>().sprite = item.data.icon;
            newItemSlot.GetComponentInChildren<TextMeshProUGUI>().text = item.data.displayName;
        }
    }

    // Cria um novo slot de item no inventário
    public void AddItemSlot()
    {
        GameObject newItemSlot = Instantiate(itemSlotPrefab, inventoryPanel.transform);
        itemSlots.Add(newItemSlot);
        numSlots++;
    }

    // Remove o último slot de item no inventário
    public void RemoveItemSlot()
    {
        if (itemSlots.Count > 0)
        {
            Destroy(itemSlots[itemSlots.Count - 1]);
            itemSlots.RemoveAt(itemSlots.Count - 1);
            numSlots--;
        }
    }
}
