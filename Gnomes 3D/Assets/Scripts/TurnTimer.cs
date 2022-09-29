using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTimer : MonoBehaviour
{
    void Start()
    {
        InvokeRepeating("TimeRanOut", 22.0f, 22.0f);
    }

    void TimeRanOut()
    {
        TurnManager.GetInstance().ChangeTurn();
    }
}
