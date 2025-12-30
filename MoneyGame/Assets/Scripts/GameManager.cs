using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
//using static UnityEngine.Rendering.DebugUI;
using System.Linq;

public class GameManager : MonoBehaviour
{
    SoundManager soundManager;
    public GameManager gameManager;
    public PaymentManager paymentManager;
    public UIManager uiManager;
    public GameDifficulty gameDifficulty;

    public Transform foodParent;

    public List <int> foodlist = new List<int>{1,2,3,4,5,6,7,8};
    public List<float> foodprices = new List<float> { 2.10f, 3.20f, 2.45f, 3.10f, 4.10f, 2.70f, 4.2f, 1.10f};
    public List<(int id, float price)> selectedFoods = new List<(int, float)>();
    public List<int> roundedfood;
    
    public int rnd;

    /*
    private void Awake()
    {
        soundManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<SoundManager>();
        DontDestroyOnLoad(gameManager.gameObject);
    }
    */

    public float GetFoodPriceByID(int foodID)
    {
        foreach (var item in selectedFoods)
        {
            if (item.id == foodID)
                return item.price;
        }

        // Should not happen, but fallback:
        return -1;
    }

    private void Start()
    {
        //gameDifficulty = (GameDifficulty)PlayerPrefs.GetInt("GameDifficulty", 1);

        roundedfood = foodprices
            .Select(p => Mathf.RoundToInt(p))
            .ToList();

        SelectRandomFoods();
        uiManager.UpdateDialogueByDifficulty(gameDifficulty);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            
        }
    }
    /*
    public void SelectDifficulty()
    {
        if (gameDifficulty == 1)
        {
            //Create a new list to store the rounded prices so as to not interfere with the original list when rounding up
            List <int> roundedfoodprices = foodprices.Select(i => Mathf.RoundToInt(i)).ToList();
            Debug.Log(string.Join(",", roundedfoodprices));
        }
    }
    */
    public void Randomiser()
    {
        //Random number generator from range (a,b)
        rnd = UnityEngine.Random.Range(1,8);
    }

    public void SelectRandomFoods()
    {
        // Pair food IDs with their prices
        var combined = foodlist
            .Zip(foodprices, (id, price) => new { id, price })
            .OrderBy(x => UnityEngine.Random.value)
            .ToList();

        // Select the first 4
        selectedFoods = combined.Take(4)
            .Select(x => (x.id, x.price))
            .ToList();

        Debug.Log("Selected Food IDs: " + string.Join(", ", selectedFoods.Select(x => x.id)));
        Debug.Log("Selected Prices: " + string.Join(", ", selectedFoods.Select(x => x.price)));

        ActivateSelectedFoods();
    }

    public void ActivateSelectedFoods()
    {
        // Turn all foods OFF first
        foreach (Transform child in foodParent)
            child.gameObject.SetActive(false);

        // Turn ON selected foods
        foreach (var item in selectedFoods)
        {
            int index = item.id - 1; // Convert foodID (1–8) to index (0–7)

            if (index >= 0 && index < foodParent.childCount)
            {
                foodParent.GetChild(index).gameObject.SetActive(true);
            }
        }
    }

    public void OnFoodSelected(int foodID)
    {
        float price;

        if (gameDifficulty == GameDifficulty.Level1)
        {
            price = GetRoundedFoodPriceByID(foodID);
        }
        else
        {
            price = GetFoodPriceByID(foodID);
        }

        paymentManager.StartPayment(price);
        uiManager.ChangeDialogue(price);

        LockFoodBtn();
    }

    public void LockFoodBtn()
    {
        foreach (Transform child in foodParent)
        {
            Button btn = child.GetComponent<Button>();
            if (btn != null)
                btn.interactable = false;
        }
    }

    public float FindFoodPrice(int foodID)
    {
        foreach (var item in selectedFoods)
        {
            if (item.id == foodID)
                return item.price;
        }
        return -1;
    }

    public void EnableFoodBtn()
    {
        foreach (Transform child in foodParent)
        {
            Button btn = child.GetComponent<Button>();
            if (btn != null)
                btn.interactable = true;
        }
    }

    public void ResetLevel()
    {
        SelectRandomFoods();
        EnableFoodBtn();
        Debug.Log("Level Reset");
    }

    public int GetRoundedFoodPriceByID(int foodID)
    {
        int index = foodID - 1;
        return roundedfood[index];
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
public enum GameDifficulty
{
    Level1 = 1,
    Level2 = 2
}
