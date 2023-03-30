using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestUIManager : MonoBehaviour
{
    [SerializeField] private GameObject questPanel;
    [SerializeField] private GameObject questSlotPrefab;
    private Dictionary<int, QuestSlotUI> questSlots = new Dictionary<int, QuestSlotUI>();
    [SerializeField] private PlayerActions player;

    private void Start()
    {
        player = FindObjectOfType<PlayerActions>();
        UpdateQuestUI();
    }

    public void UpdateQuestUI()
    {
        foreach (var slot in questSlots.Values)
        {
            slot.gameObject.SetActive(false);
        }

        foreach (var quest in player.questList)
        {
            if (!questSlots.TryGetValue(quest.questId, out var questSlot))
            {
                questSlot = Instantiate(questSlotPrefab, questPanel.transform).GetComponent<QuestSlotUI>();
                questSlots.Add(quest.questId, questSlot);
            }

            questSlot.SetQuest(quest);
            questSlot.gameObject.SetActive(true);
        }
    }

    public void AddQuest(Quest quest)
    {
        player.questList.Add(quest);
        UpdateQuestUI();
    }

    public void RemoveQuest(Quest quest)
    {
        player.questList.Remove(quest);
        UpdateQuestUI();
    }
}