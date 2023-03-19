using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class CollectItems : MonoBehaviour
{
    public int questId;

    public DialogueRunner dialogueRunner;
    public string varYarn = "$";

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            Quest relatedQuest = other.GetComponent<PlayerActions>().GetQuestById(questId);
            if (relatedQuest != null && relatedQuest.isActive)
            {               
                // Coleta o item
                relatedQuest.goal.ItemCollected();

                // Verifica se a meta da quest foi alcançada
                if (relatedQuest.goal.isReached())
                {
                    relatedQuest.Complete();
                    dialogueRunner.VariableStorage.SetValue(varYarn, true);
                }

                // Remove o item do jogo
                Destroy(gameObject);
            }
        }
    }
}
