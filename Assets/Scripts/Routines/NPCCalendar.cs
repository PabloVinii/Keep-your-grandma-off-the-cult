using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCalendar : MonoBehaviour
{
    private Itinerary activeItinerary;
    [SerializeField] private Dictionary<DayEnum, Itinerary> itineraries = new Dictionary<DayEnum, Itinerary>();
    [SerializeField] private DayNightScript dayNightScript;

    [Header("Itineraries")]
    [SerializeField] private Itinerary sundayItinerary;
    [SerializeField] private Itinerary mondayItinerary;
    [SerializeField] private Itinerary tuesdaytinerary;
    [SerializeField] private Itinerary wednesdayItinerary;
    [SerializeField] private Itinerary fridayItinerary;
    [SerializeField] private Itinerary thursdayItinerary;
    [SerializeField] private Itinerary saturdayItinerary;
    private void Awake()
    {
        SetupItineraries();
        Calendar.onDayChanged += ChangeActiveItinerary;
    }

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

    private void SetupItineraries()
    {
        itineraries.Add(DayEnum.SUNDAY, sundayItinerary);
        itineraries.Add(DayEnum.MONDAY, mondayItinerary);
        itineraries.Add(DayEnum.TUESDAY, tuesdaytinerary);
        itineraries.Add(DayEnum.WEDNESDAY, wednesdayItinerary);
        itineraries.Add(DayEnum.THURSDAY, thursdayItinerary);
        itineraries.Add(DayEnum.FRIDAY, fridayItinerary);
        itineraries.Add(DayEnum.SATURDAY, saturdayItinerary);
    }
}
