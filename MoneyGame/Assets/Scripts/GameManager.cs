using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text daysText;
    public TMP_Text moneyText;

    public int bank = 0;
    public int allowance = 10;
    public int spendings = 1;

    public int daysleft = 14;
    
    public void DaysLeftUpdate()
    {
        daysText.text = "Days left: " + daysleft;
    }

    public void UpdateMoneyText()
    {
        moneyText.text = "Money: " + bank;
    }

    private void Start()
    {
        
    }

    public void Allowance()
    {
        bank += allowance;
        UpdateMoneyText();
    }

    public void Spending()
    {
        if (bank >= spendings)
        {
            bank -= spendings;
        }
        UpdateMoneyText();
    }

}
