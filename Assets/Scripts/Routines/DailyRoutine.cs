using UnityEngine;

[CreateAssetMenu(fileName = "DailyRoutine", menuName ="ScriptableObjects/routines")]
public class DailyRoutine : ScriptableObject
{
    [SerializeField] private DayEnum day;
    [SerializeField] private Itinerary itinerary;

    public Itinerary Itinerary { get => itinerary; }
    public DayEnum Day { get => day;  }
}
