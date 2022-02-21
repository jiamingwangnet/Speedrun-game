public class TimeData
{
    public int Hours { get; set; }
    public int Minutes { get; set; }
    public int Seconds { get; set; }
    public float Milliseconds { get; set; }

    public TimeData(int hours, int minutes, int seconds, float milliseconds)
    {
        Hours = hours;
        Minutes = minutes;
        Seconds = seconds;
        Milliseconds = milliseconds;
    }
}
