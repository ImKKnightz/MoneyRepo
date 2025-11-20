using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshPro moneyText;
    public TextMeshPro dayText;
    public TextMeshPro goalText;
    public Slider goalSlider;

    public void UpdateMoneyUI(int money)
    {
        moneyText.text = "Coins: " + money;
    }

    public void UpdateDay(int day)
    {
        dayText.text = "Day: " + day;
    }

    public void GoalProgression(int current, int target)
    {
        goalSlider.maxValue = target;
        goalSlider.value = current;
        goalText.text = current + "/" + target;
    }
}
