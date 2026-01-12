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
        //dialogue.text = "Select a food item from the menu.";
    }

    public void ChangeDialogue(float price)
    {
        dialogue.text = "Your food costs: ";
        pricedialoguetext.SetActive(true);
        pricedialogue.text = "$" + price.ToString("F2"); // shows 2 decimal places
    }

    public void ResetDialogue()
    {
        pricedialogue.text = "$0.00";
    }

    public void ChangeSceneText()
    {
        dialogue.text = "Click on the person to serve them.";
    }

    public void PaymentSceneText()
    {
        dialogue.text = "Select a food item from the menu";
    }
    /*
    public void UpdateDialogueByDifficulty(GameDifficulty difficulty)
    {
        pricedialoguetext.SetActive(false);

        switch (difficulty)
        {
            case GameDifficulty.Level1:
                dialogue.text = "Click on the person to serve them.";
                break;

            case GameDifficulty.Level2:
                dialogue.text = "Select a food item from the menu.";
                break;

        }
    }
    */
}
