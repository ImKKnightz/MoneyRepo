using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject pricedialoguetext;

    public TextMeshProUGUI dialogue;
    public TextMeshProUGUI pricedialogue;

    private void Start()
    {
        pricedialoguetext.SetActive(false);
        dialogue.text = "Select a food item from the menu.";
    }

    public void ChangeDialogue(float price)
    {
        dialogue.text = "Your food costs ";
        pricedialoguetext.SetActive(true);
        pricedialogue.text = price.ToString("F2"); // shows 2 decimal places
    }
}
