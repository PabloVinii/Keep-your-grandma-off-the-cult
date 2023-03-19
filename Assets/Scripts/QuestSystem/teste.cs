using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teste : MonoBehaviour
{
    public int questId; // O ID da quest a qual esse item está vinculado

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            // Verifica se a quest relacionada a esse item está ativa
            Quest relatedQuest = other.GetComponent<PlayerActions>().GetQuestById(questId);
            if (relatedQuest != null && relatedQuest.isActive)
            {
                // Coleta o item
                relatedQuest.goal.ItemCollected();

                // Verifica se a meta da quest foi alcançada
                if (relatedQuest.goal.isReached())
                {
                    relatedQuest.Complete();
                }

                // Remove o item do jogo
                Destroy(gameObject);
            }
        }
    }
}
