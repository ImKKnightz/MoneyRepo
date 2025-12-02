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

    public int[] foodlist = {1,2,3,4,5,6,7,8};
    public float[] foodprices = { 2.10f, 3.20f, 2.45f, 3.10f, 4.10f, 2.70f, 4.2f, 1.10f};
    public List<int> check = new List<int>();
    public int gameDifficulty;
    /*
    public TextMeshProUGUI fooddialogue;
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
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            RandomFood();
            int count = check.Count();
            Debug.Log(count);
            List<int> list = check;
            foreach (int i in list)
            {
                Debug.Log(i);
            }
        }
    }

    public void SelectDifficulty()
    {
        if (gameDifficulty == 1)
        {
            int roundedfoodprices = Convert.ToInt32(foodprices[rnd - 1]);

        }
    }

    public void Randomiser()
    {
        //Random number generator from range (a,b)
        rnd = UnityEngine.Random.Range(1,8);
        
        /*//Get float value in the list
        float value = foodprices[rnd - 1];
        //Round up float value to int
        int roundedvalue = Convert.ToInt32(value);*/
    }

    public void RandomFood()
    {
        //OrderBy() function rearranges the order of foodlist
        //The () usese the UnityEngine.Random.value to randomise the elements in the list
        check = foodlist.OrderBy(x => UnityEngine.Random.value).ToList();
        Debug.Log(check);
    }

    public void GenerateRandomOrder()
    {
        check.Clear();
        List<int> temp = foodlist.ToList();

        // Fisher–Yates shuffle
        for (int i = 0; i < temp.Count; i++)
        {
            int randIndex = UnityEngine.Random.Range(i, temp.Count);
            int tempVal = temp[i];
            temp[i] = temp[randIndex];
            temp[randIndex] = tempVal;
            Debug.Log(tempVal);
        }

        check = temp;
    }

    public void SelectFood(int rnd)
    {
        
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
