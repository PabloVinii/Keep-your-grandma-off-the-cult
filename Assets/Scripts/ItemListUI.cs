using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemListUI : MonoBehaviour
{
    public GameObject itemListPanel; // Referência para o objeto de UI que contém a lista de itens coletados
    public GameObject itemImagePrefab; // Prefab para os objetos de imagem que exibem as sprites dos itens coletados
    public List<GameObject> collectedItems = new List<GameObject>(); // Lista de objetos coletados

    // Adiciona um item à lista de itens coletados e exibe sua sprite na UI
    public void AddItem(GameObject item)
    {
        // Cria um novo objeto Image para o item coletado
        GameObject newItemImage = Instantiate(itemImagePrefab, itemListPanel.transform);

        // Define a sprite do objeto Image como a sprite do item coletado
        newItemImage.GetComponent<Image>().sprite = item.GetComponent<SpriteRenderer>().sprite;

        collectedItems.Add(newItemImage);

        Destroy(item);
    }

    public void RemoveItem(GameObject item)
    {
        // Remove o item da lista de itens coletados
        collectedItems.Remove(item);

        // Procura todos os objetos filho do painel e remove o objeto de imagem correspondente
        foreach(Transform child in itemListPanel.transform)
        {
            if(child.GetComponent<Image>().sprite == item.GetComponent<Image>().sprite)
            {
                Destroy(child.gameObject);
                break;
            }
        }
    }
}
