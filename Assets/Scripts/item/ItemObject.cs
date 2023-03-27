using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class ItemObject : MonoBehaviour
{
    public int questId;
    public ItemData referenceItem;
    private InventorySystem inventory;
    public GameObject player;
    public string varYarn = "$";
    public DialogueRunner dialogueRunner;

    private void Start() {
        inventory = FindObjectOfType<InventorySystem>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;
            PickUpItem();
        }
    }

    public void PickUpItem()
    {     
        Quest relatedQuest = player.GetComponent<PlayerActions>().GetQuestById(questId);
        if (relatedQuest != null && relatedQuest.isActive)
        {
            // Coleta o item
            inventory.Add(referenceItem);
            relatedQuest.goal.ItemCollected();

            // Verifica se a meta da quest foi alcançada
            if (relatedQuest.goal.isReached())
            {
                dialogueRunner.VariableStorage.SetValue(varYarn, true);
            }

            Destroy(gameObject);
        }
        else
        {
            Debug.Log("nenhuma quest relacionada a este item");
        }     
    }
}
