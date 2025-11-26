using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    SoundManager soundManager;

    public TMP_Text daysText;
    public TMP_Text moneyText;
    public TMP_Text objText;

    public int bank = 0;
    public int allowance = 10;
    public int spendings = 1;

    public int daysleft = 14;

    private void Awake()
    {
        soundManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<SoundManager>();
    }

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
        soundManager.PlaySFX(soundManager.coinCollect);
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

    public void DayCycle()
    {
        daysleft -= 1;
        DaysLeftUpdate();
    }
}
