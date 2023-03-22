using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ititnerary", menuName = "ScriptableObjects/Itineraries")]
public class Itinerary : ScriptableObject
{
    [SerializeField] private List<Activity> openActivities = new List<Activity>();
    private List<Activity> closedActivities = new List<Activity>();

    public void RunActivities(DayNightScript dayNightScript)
    {

        if (openActivities.Count <= 0) return;

        foreach (Activity activity in openActivities)
        {

            if (closedActivities.Contains(activity)) continue;

            if (CompareTime(activity.Hour, activity.Minute, dayNightScript.hours, dayNightScript.mins))
            {
                activity.DoAction();
                closedActivities.Add(activity);
            }
        }
    }

    public void CleanClosedActivities()
    {
        if(closedActivities != null) closedActivities.Clear();
    }


    private bool CompareTime(int hour1, int minute1, int hour2, int minute2)
    {
        return hour1 == hour2 && minute1 == minute2;
    }
}
