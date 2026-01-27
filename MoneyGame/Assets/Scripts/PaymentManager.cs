using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PaymentManager : MonoBehaviour
{
    public TextMeshProUGUI totalPaidText;
    public GameObject successUI;
    public GameObject toomuchUI;
    public GameObject notenoughUI;

    public GameManager gameManager;
    public SoundManager soundManager;

    public Transform moneyDisplay;

    public float prices;
    public float totalPaid;
    public bool paymentActive;
    public int qnscounter;

    [Serializable]
    public struct MoneyVisual
    {
        public float value;
        public GameObject prefab;
    }

    public List<MoneyVisual> moneyVisuals;

    void Start()
    {
        soundManager = SoundManager.instance;
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
        SpawnMoneyVisual(amount);
        Debug.Log("Money visual added");
    }

    public void CheckPayment()
    {
        if (!paymentActive) return;

        if (Mathf.Approximately(totalPaid, prices))
        {
            paymentActive = false;
            Debug.Log("SUCCESS");

            soundManager.PlaySFX(soundManager.coinCollect);
            successUI.SetActive(true);
        }
        else if (totalPaid > prices)
        {
            toomuchUI.SetActive(true);
            soundManager.PlaySFX(soundManager.wrongClip);
            Debug.Log("TOO MUCH");
        }
        else
        {
            notenoughUI.SetActive(true);
            soundManager.PlaySFX(soundManager.wrongClip);
            Debug.Log("NOT ENOUGH");
        }
    }
    /*
    public void Retry()
    {
        
        Debug.Log("RETRY BUTTON CLICKED");
        totalPaid = 0f;
        paymentActive = true;
        UpdateUI();
        Debug.Log("Retrying");

    }
    */
    public void UpdateUI()
    {
        totalPaidText.text = $"Paid: ${totalPaid:0.00}";
        Debug.Log("Dialogue shows total payment");
    }

    public void ResetPayment()
    {
        totalPaid = 0f;
        paymentActive = true;
        UpdateUI();

        foreach (Transform child in moneyDisplay)
        {
            Destroy(child.gameObject);
        }
    }

    public void ContinueRounded()
    {
        successUI.SetActive(false);
        toomuchUI.SetActive(false);
        notenoughUI.SetActive(false);
        ResetPayment();
        qnscounter += 1;
        Debug.Log("counter updated");
        RoundedPaymenttoChange();

        gameManager.ResetLevel();
    }

    public void ContinueLvl()
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
        if(qnscounter == 4)
        {
            SceneManager.LoadScene(4);
            qnscounter = 0;
        }
        else
        {
            return;
        }
    }
    public void RoundedPaymenttoChange()
    {
        if (qnscounter == 4)
        {
            SceneManager.LoadScene(2);
            qnscounter = 0;
        }
        else
        {
            return;
        }
    }

    public void SpawnMoneyVisual(float amount)
    {
        MoneyVisual visual = moneyVisuals.Find(v => Mathf.Approximately(v.value, amount));

        if (visual.prefab != null)
        {
            Instantiate(visual.prefab, moneyDisplay);
        }
        else
        {
            Debug.LogWarning($"No money prefab for value: {amount}");
        }
    }
}
