using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    SoundManager soundManager;
    public GameManager gameManager;

    private void Awake()
    {
        soundManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<SoundManager>();
        DontDestroyOnLoad(gameManager.gameObject);
    }

    /*public void Allowance()
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
    }*/
}
