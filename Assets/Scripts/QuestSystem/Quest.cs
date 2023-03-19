using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public int questId;
    public bool isActive;    

    public string title;
    public string description;
    public int reward;

    public QuestGoal goal;

    public void Complete()
    {
        isActive = false;
        Debug.Log(title + "completado");
    }

    
}
