using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class QuestGiver : MonoBehaviour
{
    public PlayerActions player;

    public List<Quest> quests = new List<Quest>();

    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerActions>();
    }
    private void Start()
    {
        ValidateQuestIds();
    }

    [YarnCommand("listQuests")]
    public void ListQuests()
    {
        Debug.Log("Quests disponíveis:");
        foreach (Quest quest in quests)
        {
            Debug.Log(quest.questId + ": " + quest.title);
        }
    }

    [YarnCommand("quest")]
    public void Quest(int questId) {
        Quest quest = quests.Find(q => q.questId == questId);
        if (quest != null && !quest.isActive)
        {
            quest.isActive = true;
            player.questList.Add(quest);
            Debug.Log("Quest " + questId + " aceita");
        }
        else if (quest != null && quest.isActive)
        {
            Debug.Log("Quest " + questId + " já foi aceita");
        }
        else
        {
            Debug.Log("Quest " + questId + " não encontrada");
        }
    }

    [YarnCommand("finishQuest")]
    public void FinishQuest(int questId) {
        Quest questToFinish = player.GetQuestById(questId);
        if (questToFinish != null && questToFinish.isActive)
        {
            questToFinish.Complete();
            Debug.Log("Quest " + questId + " finalizada");
        }
        else if (questToFinish != null && !questToFinish.isActive)
        {
            Debug.Log("Quest " + questId + " já foi finalizada");
        }
        else
        {
            Debug.Log("Quest " + questId + " não encontrada");
        }
    }

    private void ValidateQuestIds()
    {
        List<int> idList = new List<int>();

        foreach (Quest quest in quests)
        {
            if (idList.Contains(quest.questId))
            {
                Debug.LogError("Quest ID already exists: " + quest.questId);
            }
            else
            {
                idList.Add(quest.questId);
            }
        }
    }
    }
    
