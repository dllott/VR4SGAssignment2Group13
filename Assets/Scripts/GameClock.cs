using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

//static var hour = 6;

public class GameClock : MonoBehaviour
{
    public int day = 0;
    public int maxDay = 28;
    private Text displayClock;
    public Health hunger;
    public int hour = 7;
    static int minutes = 0;
    static string dayNight = "A.M.";
    double secondsSinceStart = 0.0;
    public bool bedTime = false;
    // Start is called before the first frame update
    void Start()
    {
        hunger = GameObject.Find("fridge").GetComponent<Health>();
        displayClock = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Time.time - secondsSinceStart > 1.0)
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
                        //insul.SetNeed(true);
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
        }*/
        string dispHour = LeadingZero(hour);
        string dispMinutes = LeadingZero(minutes);
        displayClock.text = dispHour + ":" + dispMinutes + dayNight;
        if(dayNight == "P.M." && hour > 7 || dayNight == "A.M." && hour < 6)
        {
            bedTime = true;
        } else
        {
            bedTime = false;
        }
    }
    public void working()
    {
        hunger.CountHunger(2);
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
    public void MoveTime(int t)
    {
        hour += t;
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
