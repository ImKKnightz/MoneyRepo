using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    public int currentmoney {  get; private set; } = 0;

    public void EarnMoney(int amount)
    {
        currentmoney += amount;
    }

    public bool TrySpend(int amount)
    {
        if (currentmoney >= amount)
        {
            currentmoney -= amount;
            return true;
        }
        return false;
    }
}
