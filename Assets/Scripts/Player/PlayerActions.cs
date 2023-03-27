using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public List<Quest> questList = new List<Quest>();
    
    public bool flashLightActive = false;
    public GameObject flashLight;

    // Update is called once per frame
    void Update()
    {
        
        ToggleFlashLight();
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
}
