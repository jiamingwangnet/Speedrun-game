using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private int hours;
    [SerializeField] private int minutes;
    [SerializeField] private int seconds;
    [SerializeField] private float milliseconds;
    [Space(5)]
    [SerializeField] private TMP_Text timeText;

    public int Hours { get => hours; }
    public int Minutes { get => minutes; }
    public int Seconds { get => seconds; }
    public float Milliseconds { get => milliseconds; }

    public TimeData TimerData { get; set; }
    public bool DoNotSetTime { get; set; }

    private void Start()
    {
        if(!DoNotSetTime)
            TimerData = new TimeData(hours, minutes, seconds, milliseconds);
    }

    // Update is called once per frame
    void Update()
    {
        string formattedMillisec = ((int)TimerData.Milliseconds < 100 ? ((int)TimerData.Milliseconds < 10 ? "00" + ((int)TimerData.Milliseconds) 
            : "0" + ((int)TimerData.Milliseconds)) 
            : ((int)TimerData.Milliseconds).ToString());
        string formattedHours = (TimerData.Hours < 10 ? "0" + TimerData.Hours : TimerData.Hours.ToString());
        string formattedMinutes = (TimerData.Minutes < 10 ? "0" + TimerData.Minutes : TimerData.Minutes.ToString());
        string formattedSeconds = (TimerData.Seconds < 10 ? "0" + TimerData.Seconds : TimerData.Seconds.ToString());


        string time = $"{formattedHours}:" +
            $"{formattedMinutes}:" +
            $"{formattedSeconds}." +
            $"{formattedMillisec}";
        

        timeText.text = time;

        if(TimerData.Milliseconds >= 1000f)
        {
            TimerData.Milliseconds = 0f;
            TimerData.Seconds++;
        }

        if (TimerData.Seconds >= 60)
        {
            TimerData.Seconds = 0;
            TimerData.Minutes++;
        }

        if (TimerData.Minutes >= 60)
        {
            TimerData.Minutes = 0;
            TimerData.Hours++;
        }

        TimerData.Milliseconds += Time.deltaTime * 1000f;
    }
}
