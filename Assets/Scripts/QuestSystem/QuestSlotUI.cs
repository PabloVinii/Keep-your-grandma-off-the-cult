using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestSlotUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private TextMeshProUGUI reward;

    public Quest quest;

    public void SetQuest(Quest newQuest)
    {
        quest = newQuest;
        title.text = quest != null ? quest.title : "";
        reward.text = quest != null ? quest.reward.ToString() : "";
    }
}
