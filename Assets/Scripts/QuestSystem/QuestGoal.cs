using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal
{
    public GoalType goalType;

    public string itemID;
    public int requiredAmount;
    public int currentAmount;

    public bool isReached()
    {
        return (currentAmount >= requiredAmount);
    }

    public void ItemCollected()
    {
        if(goalType == GoalType.Gathering)
        {
            currentAmount++;
        }
    }

    public void TalkedTo()
    {
        if(goalType == GoalType.Talk)
        {
            currentAmount++;
        }
    }
}

public enum GoalType
{
    Gathering,
    Talk
}
