using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class CollectItems : MonoBehaviour
{
    public int questId;

    private DialogueRunner dialogueRunner;
    public string varYarn = "$";

    // Referência para o script Inventory
    public PlayerInventory inventory;

    private void Start() {
        dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
        inventory = FindObjectOfType<PlayerInventory>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            Quest relatedQuest = other.GetComponent<PlayerActions>().GetQuestById(questId);
            if (relatedQuest != null && relatedQuest.isActive)
            {               
                // Coleta o item e adiciona ao inventário do jogador
                inventory.AddItem(gameObject.GetComponent<ItemObject>().item);

                // Verifica se a meta da quest foi alcançada
                relatedQuest.goal.ItemCollected();
                if (relatedQuest.goal.isReached())
                {
                    dialogueRunner.VariableStorage.SetValue(varYarn, true);
                }

                // Remove o item do mundo
                Destroy(gameObject);
            }
        }
    }
}
