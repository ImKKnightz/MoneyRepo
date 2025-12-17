using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using static UnityEngine.Rendering.DebugUI;
using System.Linq;

public class GameManager : MonoBehaviour
{
    SoundManager soundManager;
    public GameManager gameManager;
    public PaymentManager paymentManager;

    public Transform foodParent;

    public List <int> foodlist = new List<int>{1,2,3,4,5,6,7,8};
    public List<float> foodprices = new List<float> { 2.10f, 3.20f, 2.45f, 3.10f, 4.10f, 2.70f, 4.2f, 1.10f};
    public List<(int id, float price)> selectedFoods = new List<(int, float)>();

    
    public int gameDifficulty;
    /*
    
    public TextMeshProUGUI pricedialogue;

    public GameObject foodtext;
    public GameObject pricedialoguetext;

    public GameObject food1;
    public GameObject food2;
    public GameObject food3;
    public GameObject food4;
    public GameObject food5;
    public GameObject food6;
    public GameObject food7;
    public GameObject food8;

    public GameObject deselectfood1;
    public GameObject deselectfood2;
    public GameObject deselectfood3;
    public GameObject deselectfood4;
    public GameObject deselectfood5;
    public GameObject deselectfood6;
    public GameObject deselectfood7;
    public GameObject deselectfood8;
    */
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
        /*
        food1.SetActive(false);
        food2.SetActive(false);
        food3.SetActive(false);
        food4.SetActive(false);
        food5.SetActive(false);
        food6.SetActive(false);
        food7.SetActive(false);
        food8.SetActive(false);

        deselectfood1.SetActive(false);
        deselectfood2.SetActive(false);
        deselectfood3.SetActive(false);
        deselectfood4.SetActive(false);
        deselectfood5.SetActive(false);
        deselectfood6.SetActive(false);
        deselectfood7.SetActive(false);
        deselectfood8.SetActive(false);
        
        foodtext.SetActive(true);
        pricedialoguetext.SetActive(false);
        fooddialogue.text = "Select a food item from the menu.";
        */

        gameDifficulty = 1;

        SelectRandomFoods();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            
        }
    }

    public void SelectDifficulty()
    {
        if (gameDifficulty == 1)
        {
            //Create a new list to store the rounded prices so as to not interfere with the original list when rounding up
            List <int> roundedfoodprices = foodprices.Select(i => Mathf.RoundToInt(i)).ToList();
            Debug.Log(string.Join(",", roundedfoodprices));
        }
    }

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
        // foodID is 1–8
        float price = GetFoodPriceByID(foodID);

        if (price < 0)
        {
            Debug.LogError("Food not found!");
            return;
        }

        paymentManager.StartPayment(price);

        Debug.Log($"Food {foodID} selected, price: {price}");

        // Lock food selection here if needed
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

    public void ChangeDialogue()
    {
        
        //foodtext.SetActive(false);
        //pricedialoguetext.SetActive(true);
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
