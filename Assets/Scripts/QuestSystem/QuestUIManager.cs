using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestUIManager : MonoBehaviour
{
    [SerializeField] private GameObject questPanel;
    [SerializeField] private GameObject questSlotPrefab;
    [SerializeField] private PlayerActions player;
    private Dictionary<int, QuestSlotUI> questSlots = new Dictionary<int, QuestSlotUI>();
    private bool showOnlyActiveQuests = false; // variável para indicar se exibir apenas missões ativas

    private void Start()
    {
        player = FindObjectOfType<PlayerActions>();
        UpdateQuestUI();
    }

    public void UpdateQuestUI()
    {
        foreach (var slot in questSlots.Values)
        {
            bool shouldShowSlot = !showOnlyActiveQuests || slot.quest != null && slot.quest.isActive; // verifica se deve exibir o slot de missão
            slot.gameObject.SetActive(shouldShowSlot);
        }

        foreach (var quest in player.questList)
        {
            if (!questSlots.TryGetValue(quest.questId, out var questSlot))
            {
                questSlot = Instantiate(questSlotPrefab, questPanel.transform).GetComponent<QuestSlotUI>();
                questSlots.Add(quest.questId, questSlot);
            }

            questSlot.SetQuest(quest);
            bool shouldShowSlot = !showOnlyActiveQuests || quest.isActive; // verifica se deve exibir o slot de missão
            questSlot.gameObject.SetActive(shouldShowSlot);
        }
    }

    public void OnShowOnlyActiveQuestsClicked()
    {
        showOnlyActiveQuests = !showOnlyActiveQuests; // inverte o valor da variável showOnlyActiveQuests
        UpdateQuestUI();
    }
}


