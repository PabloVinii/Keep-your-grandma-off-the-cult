using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itinerary : MonoBehaviour
{
    [SerializeField] private List<Activity> openActivities = new List<Activity>();
    private List<Activity> closedActivities = new List<Activity>();
    [SerializeField] private DayNightScript dayNightScript;
    void Update()
    {

        if(openActivities.Count <= 0) return;

        foreach(Activity activity in openActivities){

            if(closedActivities.Contains(activity)) continue;

            if(CompareTime(activity.Hour, activity.Minute, dayNightScript.hours, dayNightScript.mins)){
                activity.DoAction();
                closedActivities.Add(activity);
            }
        }
    }

    private bool CompareTime(int hour1, int minute1, int hour2, int minute2){
        return hour1 == hour2 && minute1 == minute2;
    }
}
