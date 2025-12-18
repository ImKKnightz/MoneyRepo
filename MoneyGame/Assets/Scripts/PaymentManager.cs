using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PaymentManager : MonoBehaviour
{
    public TextMeshProUGUI totalPaidText;
    public GameObject successUI;
    public GameManager gameManager;

    public float prices;
    public float totalPaid;
    public bool paymentActive;
    public int qnscounter;

    void Start()
    {
        ResetPayment();
        successUI.SetActive(false);
    }

    // Called after food is selected
    public void StartPayment(float selectedprice)
    {
        prices = selectedprice;
        totalPaid = 0f;
        paymentActive = true;

        Debug.Log("Start payment");
        Debug.Log(selectedprice);

        UpdateUI();
    }

    // Called by money buttons
    public void AddMoney(float amount)
    {
        if (!paymentActive) return;

        totalPaid += amount;
        Debug.Log("Money added");
        UpdateUI();
        Debug.Log("UI updated");
    }

    public void CheckPayment()
    {
        if (!paymentActive) return;

        if (Mathf.Approximately(totalPaid, prices))
        {
            paymentActive = false;
            Debug.Log("SUCCESS");

            successUI.SetActive(true);
        }
        else if (totalPaid > prices)
        {
            Debug.Log("TOO MUCH");
        }
        else
        {
            Debug.Log("NOT ENOUGH");
        }
    }

    public void Retry()
    {
        
        Debug.Log("RETRY BUTTON CLICKED");
        totalPaid = 0f;
        paymentActive = true;
        UpdateUI();
        Debug.Log("Retrying");
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

    public void ContinueLevel()
    {
        successUI.SetActive(false);
        ResetPayment();
        qnscounter += 1;
        Debug.Log("counter updated");
        PaymenttoChange();

        gameManager.ResetLevel();
    }

    public void PaymenttoChange()
    {
        if(qnscounter >= 4)
        {
            SceneManager.LoadScene(2);
        }
        else
        {
            return;
        }
    }
}
