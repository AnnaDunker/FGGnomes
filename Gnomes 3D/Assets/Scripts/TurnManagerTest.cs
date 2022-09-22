using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManagerTest : MonoBehaviour
{
   private static TurnManagerTest instance;
    private int currentPlayerIndex;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            currentPlayerIndex = 1;
        }
    }

    public bool IsItPlayerTurn(int index)
    {
        return index == currentPlayerIndex;
    }

    public static TurnManagerTest GetInstance()
    {
        return instance;    
    }

    public void ChangeTurn()
    {
        if (currentPlayerIndex == 1)
        {
            currentPlayerIndex = 2;
        }
        else if (currentPlayerIndex == 2)
        {
            currentPlayerIndex = 1;
        }
    }

}
