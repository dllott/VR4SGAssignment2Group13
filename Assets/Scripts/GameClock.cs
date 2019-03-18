using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

//static var hour = 6;

public class GameClock : MonoBehaviour
{
    private Text displayClock;
    public int hour = 7;
    static int minutes = 0;
    static string dayNight = "A.M.";
    double secondsSinceStart = 0.0;
    // Start is called before the first frame update
    void Start()
    {
        displayClock = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - secondsSinceStart > 1.0)
        {
            minutes++;
            if(minutes == 60)
            {
                minutes = 0;
                hour++;
                if(hour >= 12)
                {
                    if (dayNight == "A.M.")
                    {
                        dayNight = "P.M.";
                    }
                    else
                    {
                        hour = 7;
                        dayNight = "A.M.";
                    }
                }
                if(hour >= 13)
                {
                    hour -= 12;
                }

            }
            secondsSinceStart = Time.time;
        }
        string dispHour = LeadingZero(hour);
        string dispMinutes = LeadingZero(minutes);
        displayClock.text = dispHour + ":" + dispMinutes + dayNight;
    }
    public void working()
    {
        hour += 7;
        if (hour >= 12)
        {
            if (dayNight == "A.M.")
            {
                dayNight = "P.M.";
            }
            else
            {
                hour = 7;
                dayNight = "A.M.";
            }
        }
        if (hour >= 13)
        {
            hour -= 12;
        }
    }
    string LeadingZero(int x)
    {
        return x.ToString().PadLeft(2, '0');
    }
}
