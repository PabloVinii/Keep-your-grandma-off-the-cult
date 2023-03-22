using System;
using UnityEngine;

public class Calendar : MonoBehaviour
{
    public static Action<DayEnum> onDayChanged;

    [SerializeField] private DayEnum actualDay;

    public DayEnum ActualDay { get => actualDay; private set => actualDay = value; }

    private void OnEnable() => DayNightScript.onDayChanged += PassDay;
    private void OnDisable() => DayNightScript.onDayChanged -= PassDay;

    public void PassDay()
    {
        if ((int)ActualDay == 7)
        {
            ActualDay = DayEnum.SUNDAY;
            onDayChanged?.Invoke(actualDay);
            return;
        }

        ActualDay = ActualDay + 1;
        onDayChanged?.Invoke(actualDay);
    }


}
