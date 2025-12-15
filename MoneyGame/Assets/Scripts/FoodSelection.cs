using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodSelection : MonoBehaviour
{
    public float foodPrice;
    public PaymentManager paymentManager;
    public Button foodButton;

    public void SelectFood()
    {
        // Disable all food buttons
        foreach (FoodSelection f in FindObjectsOfType<FoodSelection>())
        {
            f.foodButton.interactable = false;
        }

        paymentManager.StartPayment(foodPrice);
    }
}
