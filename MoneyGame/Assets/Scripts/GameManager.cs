using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static class Wallet
    {
        public static int Money = 0;

        public static void Add(int amount)
        {
            Money += amount;
        }

        public static bool Spend(int amount)
        {
            if (Money >= amount)
            {
                Money -= amount;
                return true;
            }
            return false;
        }
    }

    [Header("Game Setup")] public int dailyIncome = 10;
    public int goalAmount = 100;
    public int maxDays = 10;
    private int currentDay = 1;

    [Header("UI")] public Text moneyText;
    public TextMeshPro dayText;
    public Slider goalSlider;
    public TextMeshPro goalLabel;
    public GameObject failScreen;
    public TextMeshPro failMessage;

    private void Start()
    {
        UpdateUI();
    }

    public void CollectIncome()
    {
        Wallet.Add(dailyIncome);
        SoundManager.Instance.Play("Collect");
        UpdateUI();
    }

    public void NextDay()
    {
        currentDay++;
        UpdateUI();
        CheckEndConditions();
    }

    private void CheckEndConditions()
    {
        if (currentDay > maxDays)
        {
            if (Wallet.Money >= goalAmount)
                Debug.Log("MISSION SUCCESS");
            else
                MissionFail();
        }
    }

    private void MissionFail()
    {
        failScreen.SetActive(true);
        failMessage.text = "MISSION FAILED You did not save enough.";
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    private void UpdateUI()
    {
        if (moneyText != null) moneyText.text = "Coins: " + Wallet.Money;
        if (dayText != null) dayText.text = "Day: " + currentDay;


        if (goalSlider != null)
        {
            goalSlider.maxValue = goalAmount;
            goalSlider.value = Wallet.Money;
        }


        if (goalLabel != null)
            goalLabel.text = Wallet.Money + "/" + goalAmount;
    }
}
