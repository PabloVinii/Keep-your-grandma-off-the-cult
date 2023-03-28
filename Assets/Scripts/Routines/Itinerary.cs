using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ititnerary", menuName = "ScriptableObjects/Itineraries")]
public class Itinerary : ScriptableObject
{
    [SerializeField] private List<TimeActivity> openActivities = new List<TimeActivity>();
    private HashSet<TimeActivity> closedActivities = new HashSet<TimeActivity>();

    public void RunActivities(DayNightScript dayNightScript)
    {

        if (openActivities.Count <= 0) return;

        foreach (TimeActivity timeActivity in openActivities)
        {

            if (closedActivities.Contains(timeActivity)) continue;

            if (CompareTime(timeActivity.Hour, timeActivity.Minute, dayNightScript.hours, dayNightScript.mins))
            {
                timeActivity.Activity.DoAction();
                closedActivities.Add(timeActivity);
            }
        }
    }

    public void CleanClosedActivities() => closedActivities?.Clear();

    private bool CompareTime(int hour1, int minute1, int hour2, int minute2)
    {
        return hour1 == hour2 && minute1 == minute2;
    }
}

[System.Serializable]
public class TimeActivity{
    [SerializeField] private int hour;
    [SerializeField] private int minute;
    [SerializeField] private Activity activity;

    public int Minute { get => minute; set => minute = value; }
    public int Hour { get => hour; set => hour = value; }
    public Activity Activity { get => activity; set => activity = value; }
}
