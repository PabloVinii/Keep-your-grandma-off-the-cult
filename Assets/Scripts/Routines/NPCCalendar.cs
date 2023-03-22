using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCalendar : MonoBehaviour
{
    private Itinerary activeItinerary;
    [SerializeField] private List<DailyRoutine> routines = new List<DailyRoutine>();
    [SerializeField] private Dictionary<DayEnum, Itinerary> itineraries = new Dictionary<DayEnum, Itinerary>();
    [SerializeField] private DayNightScript dayNightScript;

    private void Awake()
    {
        foreach (DailyRoutine routine in routines)
        {
            itineraries.Add(routine.Day, routine.Itinerary);
        }

        ChangeActiveItinerary(DayEnum.SUNDAY);
    }

    private void OnEnable() => Calendar.onDayChanged += ChangeActiveItinerary;
    private void OnDisable() => Calendar.onDayChanged -= ChangeActiveItinerary;

    private void Update()
    {
        activeItinerary.RunActivities(dayNightScript);
    }

    private void ChangeActiveItinerary(DayEnum dayEnum)
    {
        if (activeItinerary != null)
        {
            activeItinerary.CleanClosedActivities();
        }
        
        activeItinerary = itineraries[dayEnum];
    }
}
