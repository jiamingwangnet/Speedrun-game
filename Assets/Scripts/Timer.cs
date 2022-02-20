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

    // Update is called once per frame
    void Update()
    {
        string formattedMillisec = ((int)milliseconds < 100 ? ((int)milliseconds < 10 ? "00" + ((int)milliseconds) : "0" + ((int)milliseconds)) : ((int)milliseconds).ToString());
        string formattedHours = (hours < 10 ? "0" + hours : hours.ToString());
        string formattedMinutes = (minutes < 10 ? "0" + minutes : minutes.ToString());
        string formattedSeconds = (seconds < 10 ? "0" + seconds : seconds.ToString());


        string time = $"{formattedHours}:" +
            $"{formattedMinutes}:" +
            $"{formattedSeconds}." +
            $"{formattedMillisec}";
        

        timeText.text = time;

        if(milliseconds >= 1000f)
        {
            milliseconds = 0f;
            seconds++;
        }

        if (seconds >= 60)
        {
            seconds = 0;
            minutes++;
        }

        if (minutes >= 60)
        {
            minutes = 0;
            hours++;
        }

        milliseconds += Time.deltaTime * 1000f;
    }
}
