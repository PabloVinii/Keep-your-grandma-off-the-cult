using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class CollectItems : MonoBehaviour
{
    public int questId;

    private DialogueRunner dialogueRunner;
    public string varYarn = "$";

    // Referência para o script ItemListUI
    public ItemListUI itemListUI;

    private void Start() {
        dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
        itemListUI = FindAnyObjectByType<ItemListUI>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            Quest relatedQuest = other.GetComponent<PlayerActions>().GetQuestById(questId);
            if (relatedQuest != null && relatedQuest.isActive)
            {               
                // Coleta o item
                relatedQuest.goal.ItemCollected();

                // Adiciona o item à lista de itens coletados e exibe sua sprite na UI
                itemListUI.AddItem(gameObject);

                // Verifica se a meta da quest foi alcançada
                if (relatedQuest.goal.isReached())
                {
                    dialogueRunner.VariableStorage.SetValue(varYarn, true);
                }

            }
        }
    }
}
