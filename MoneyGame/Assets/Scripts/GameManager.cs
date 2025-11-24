using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text text;

    public int bank = 0;
    public int allowance = 10;
    public int spendings = 1;

    private void TextUpdate()
    {
        text.text = "Days: ";
    }

    private void Start()
    {
        TextUpdate();
    }

    public void Allowance()
    {
        bank += allowance;
    }

    public void Spending()
    {
        bank -= spendings;
    }
}
