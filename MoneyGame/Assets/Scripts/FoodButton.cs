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

    public void Add5Cents()
    {

    }

    public void Add10cents()
    {

    }

    public void Add20Cents()
    {

    }

    public void Add50Cents()
    {

    }

    public void Add1Dollar()
    {

    }

    public void Add2Dollar()
    {

    }

    public void Add5Dollar()
    {

    }

    public void Add10Dollar()
    {

    }

    public void Add50Dollar()
    {

    }

    public void Add100Dollar()
    {

    }
}
