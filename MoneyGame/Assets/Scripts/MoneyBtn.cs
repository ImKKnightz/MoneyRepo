using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyBtn : MonoBehaviour
{
    public float value;
    public PaymentManager paymentManager;

    public void AddMoney()
    {
        paymentManager.AddMoney(value);
        Debug.Log("Added" + value);
    }
}
