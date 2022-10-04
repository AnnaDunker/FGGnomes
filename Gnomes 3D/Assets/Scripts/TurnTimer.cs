using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnTimer : MonoBehaviour
{
    [SerializeField] private Text countdownTimer;
    /*static DateTime TimeStarted;
    static TimeSpan TotalTime;

    public static void StartCountDown(TimeSpan totalTime)
    {
        TimeStarted = DateTime.UtcNow;
        TotalTime = totalTime;
    }

    public static TimeSpan TimeLeft
    {
        get
        {
            var result = TotalTime - (DateTime.UtcNow - TimeStarted);
            if (result.TotalSeconds <= 0)
                return TimeSpan.Zero;
            return result;
        }
    }*/
    void Start()
    {
        InvokeRepeating("TimeRanOut", 20.0f, 20.0f);
    }

    private void Update()
    {
         
    }

    public void TimeRanOut()
    {
        TurnManager.GetInstance().ChangeTurn();
    }
}
