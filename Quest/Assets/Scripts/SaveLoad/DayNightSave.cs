using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightSave : SaveObject
{
    [SerializeField] [Tooltip("количество минут в дне")] private int DayDuration = 240; // 4 минуты
    [SerializeField] [Tooltip("Начало дня в часах")] private float startDayHour = 12;
    [SerializeField] float minuteDuration;
    [SerializeField] float hourDuration;
    [SerializeField] float timeFromStart;
    public int Days => (int)timeFromStart / DayDuration;
    public int Hours => Mathf.FloorToInt((timeFromStart % DayDuration) / hourDuration);
    public int Minutes => Mathf.FloorToInt((timeFromStart % DayDuration % hourDuration) / minuteDuration);

    public float ProgressDay=> (float)(Hours * 60 + Minutes) / 1440;
    void Start()
    {
        Load();
        hourDuration = (float)DayDuration / 24;
        minuteDuration = hourDuration / 60;
        //timeFromStart = startDayHour * hourDuration;

    }
    private void Update()
    {
        timeFromStart += Time.deltaTime;
    }
}
