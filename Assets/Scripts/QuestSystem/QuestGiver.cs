using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    public PlayerMovement player;
    public Quest quest;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            quest.isActive = true;
            player.questList.Add(quest);
        }
    }
    }
    
