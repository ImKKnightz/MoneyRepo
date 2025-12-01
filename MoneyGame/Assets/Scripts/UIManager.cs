using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject foodtext;
    public GameObject pricedialoguetext;

    public TextMeshProUGUI fooddialogue;
    public TextMeshProUGUI pricedialogue;

    private void Start()
    {
        foodtext.SetActive(true);
        pricedialoguetext.SetActive(false);
        fooddialogue.text = "Select a food item from the menu.";
    }

    public void ChangeDialogue()
    {
        foodtext.SetActive(false);
        pricedialoguetext.SetActive(true);
    }
}
