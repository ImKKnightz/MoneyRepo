using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodButton : MonoBehaviour
{
    public int foodID;  // Assign in Inspector (1–8)
    public int foodcost;

    public void OnClickFood()
    {
        float price = GameObject.Find("GameManager").GetComponent<GameManager>().GetFoodPriceByID(foodID);

        UIManager ui = GameObject.Find("UIManager").GetComponent<UIManager>();
        ui.ChangeDialogue(price);
    }
}
