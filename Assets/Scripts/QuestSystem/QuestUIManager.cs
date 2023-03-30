using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestUIManager : MonoBehaviour
{
    public GameObject questPanel; // Referência para o objeto de UI que contém a lista de quests do jogador
    public GameObject questSlotPrefab; // Prefab para os slots de quests na UI
    public List<GameObject> questSlots = new List<GameObject>(); // Lista de slots de quests na UI

    [SerializeField] private PlayerActions player; // Referência para o jogador

    private void Start()
    {
        player = FindObjectOfType<PlayerActions>();

        // Cria os slots de quests na UI
        UpdateQuestUI();
    }

    // Atualiza a UI das quests
    public void UpdateQuestUI()
    {
        // Remove todos os slots de quests da UI
        foreach (GameObject slot in questSlots)
        {
            Destroy(slot);
        }
        questSlots.Clear();

        // Cria os slots de quests com base na lista de quests do jogador
        foreach (Quest quest in player.questList)
        {
            GameObject newQuestSlot = Instantiate(questSlotPrefab, questPanel.transform);
            questSlots.Add(newQuestSlot);

            // Atualiza os campos de texto do slot de quest na UI
            QuestSlotUI questSlotUI = newQuestSlot.GetComponentInChildren<QuestSlotUI>();
            questSlotUI.title.text = quest.title;
            questSlotUI.description.text = quest.description;
            questSlotUI.reward.text = quest.reward.ToString();
        }
    }

    // Adiciona uma nova quest à lista de quests do jogador e atualiza a UI
    public void AddQuest(Quest quest)
    {
        player.questList.Add(quest);
        UpdateQuestUI();
    }

    // Remove uma quest da lista de quests do jogador e atualiza a UI
    public void RemoveQuest(Quest quest)
    {
        player.questList.Remove(quest);
        UpdateQuestUI();
    }
}
