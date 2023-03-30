using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestSlotUI : MonoBehaviour
{
    public TextMeshProUGUI title;
    public TextMeshProUGUI description;
    public TextMeshProUGUI reward;

    private Quest quest;

    public Quest Quest
    {
        get { return quest; }
        set
        {
            quest = value;
            if (quest != null)
            {
                title.text = quest.title;
                reward.text = quest.reward.ToString();
            }
            else
            {
                title.text = "";
            }
        }
    }

}
