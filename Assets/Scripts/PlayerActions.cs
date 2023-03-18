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
        foreach (Quest quest in questList)
        {
            // Verifica se a quest está ativa e se o jogador pressionou a tecla E
            if (quest.isActive && Input.GetKeyDown(KeyCode.Q))
            {
                quest.goal.ItemCollected();

                // Verifica se a meta da quest foi alcançada
                if (quest.goal.isReached())
                {
                    quest.Complete();
                }
            }
        }
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
