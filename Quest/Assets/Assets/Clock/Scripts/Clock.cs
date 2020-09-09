using UnityEngine;
using System.Collections;

public class Clock : MonoBehaviour
{
   private  GameObject pointerMinutes;
   private  GameObject pointerHours;

    void Start()
    {
        pointerMinutes = transform.Find("rotation_axis_pointer_minutes").gameObject;
        pointerHours = transform.Find("rotation_axis_pointer_hour").gameObject;
    }

    void Update()
    {
        float rotationMinutes = (360.0f / 60.0f) * DayNight.Instance.Minutes;
        float rotationHours = ((360.0f / 12.0f) * DayNight.Instance.Hours) + ((360.0f / (60.0f * 12.0f)) * DayNight.Instance.Minutes);

        pointerMinutes.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationMinutes);
        pointerHours.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationHours);
    }
}
