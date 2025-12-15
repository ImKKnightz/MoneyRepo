using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PaymentManager : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI totalPaidText;

    [Header("State")]
    public float foodPrice;
    public float totalPaid;
    public bool paymentActive;

    void Start()
    {
        ResetPayment();
    }

    // Called after food is selected
    public void StartPayment(float price)
    {
        foodPrice = price;
        totalPaid = 0f;
        paymentActive = true;

        Debug.Log("Start payment");

        UpdateUI();
        dialogueText.text = $"Please pay ${foodPrice:0.00}";
    }

    // Called by money buttons
    public void AddMoney(float amount)
    {
        if (!paymentActive) return;

        totalPaid += amount;
        Debug.Log("Money added");
        UpdateUI();
        Debug.Log("UI updated");

        CheckPayment();
    }

    public void CheckPayment()
    {
        if (Mathf.Approximately(totalPaid, foodPrice))
        {
            paymentActive = false;
            dialogueText.text = "Correct! Payment successful.";
            Debug.Log("SUCCESS");
        }
        else if (totalPaid > foodPrice)
        {
            paymentActive = false;
            dialogueText.text = "Too much! Press Retry.";
            Debug.Log("FAILED - TOO MUCH");
        }
    }

    public void Retry()
    {
        if (!paymentActive)
        {
            totalPaid = 0f;
            paymentActive = true;
            UpdateUI();
            dialogueText.text = $"Try again. Pay ${foodPrice:0.00}";
        }
    }

    public void UpdateUI()
    {
        totalPaidText.text = $"Paid: ${totalPaid:0.00}";
        Debug.Log("Dialogue shows total payment");
    }

    public void ResetPayment()
    {
        totalPaid = 0f;
        paymentActive = false;
        UpdateUI();
    }
}
