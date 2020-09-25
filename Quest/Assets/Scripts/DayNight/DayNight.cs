using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : GenericSingletonClass<DayNight>
{
    public DayNightSave save;
    public Action TimeChanged = delegate { };

    public int Days => save.Days;
    public int Hours => save.Hours;
    public int Minutes => save.Minutes;
    public float ProgressDay => save.ProgressDay;

    private void Update()
    {
        TimeChanged();
    }
}



