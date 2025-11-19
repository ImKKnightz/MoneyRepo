using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncomeManager : MonoBehaviour
{
    public int dailyIncome = 10;
    public Action <int> OnIncomeCollected;

    public void CollectDailyIncome()
    {
        OnIncomeCollected?.Invoke(dailyIncome);
    }
}
