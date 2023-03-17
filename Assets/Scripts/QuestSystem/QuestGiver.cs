using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class QuestGiver : MonoBehaviour
{
    public PlayerMovement player;
    public Quest quest;

    [YarnCommand("quest")]
    public void Quest() {
        quest.isActive = true;
        player.questList.Add(quest);
        Debug.Log("quest aceita");
    }
    }
    
