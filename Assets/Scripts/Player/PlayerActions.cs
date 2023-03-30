using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public List<Quest> questList = new List<Quest>();
    public GameObject questUIPanel;
    public bool isQuestUIActive = false; // booleano para controlar a visibilidade da tela de quests
    public bool flashLightActive = false;
    public GameObject flashLight;

    // Update is called once per frame
    void Update()
    {
        
        ToggleFlashLight();
        ToggleQuestUI();
    }

    public Quest GetQuestById(int id)
    {
        foreach (Quest quest in questList)
        {
            if (quest.questId == id)
            {
                return quest;
            }
        }

        return null;
    }

    void ToggleFlashLight()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if (flashLightActive == false)
            {
                flashLight.gameObject.SetActive(true);            
                flashLightActive = true;
            }
            else
            {
                flashLight.gameObject.SetActive(false);
                flashLightActive = false;
            }
        }
    }

    void ToggleQuestUI()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            if (isQuestUIActive == false)
            {
                questUIPanel.SetActive(true);            
                isQuestUIActive = true;
            }
            else
            {
                questUIPanel.SetActive(false);
                isQuestUIActive = false;
            }
        }
    }

}
