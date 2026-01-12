using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Linq;
using UnityEngine.SceneManagement;

public class ChangeManager : MonoBehaviour
{
    public List<int> changelist = new List<int> {1,2,3,4,5,6,7,8};
    public List<float> changeamount = new List<float> {1.2f, 5.55f, 9.5f, 4.2f, 3.85f, 6.1f, 2.9f, 8.65f};
    public List<(int id, float price)> selectedchange = new List<(int, float)>();
    public List<int> roundedchange;

    public Transform changeParent;

    public PaymentManager paymentmanager;
    public UIManager UIManager;
    public SceneChanger changer;
    public GameDifficulty GameDifficulty;

    public GameObject successpanel;

    public int selectedchangeID;
    public float selectedchangeamt;
    public int counter = 0;

    public void SelectRandomChange()
    {
        int randomIndex = UnityEngine.Random.Range(0, changelist.Count);

        selectedchangeID = changelist[randomIndex];
        selectedchangeamt = changeamount[randomIndex];

        ActivateSelectedChange();

        Debug.Log($"Selected Item ID: {selectedchangeID}, Price: {selectedchangeamt}");
    }

    public void ActivateSelectedChange()
    {
        foreach (Transform child in changeParent)
            child.gameObject.SetActive(false);

        changeParent.GetChild(selectedchangeID - 1).gameObject.SetActive(true);
    }

    public void OnChangeSelected(int changeID)
    {
        if (changeID != selectedchangeID) return;

        float price =
            GameDifficulty == GameDifficulty.Level1
            ? roundedchange[changeID - 1]
            : selectedchangeamt;

        paymentmanager.StartPayment(price);
        UIManager.ChangeDialogue(price);

        LockItemBtn();
    }

    public void LockItemBtn()
    {
        foreach (Transform child in changeParent)
        {
            Button btn = child.GetComponent<Button>();
            if (btn != null)
                btn.interactable = false;
        }
    }

    public void UnlockChangeBtn()
    {
        foreach (Transform child in changeParent)
        {
            Button btn = child.GetComponent<Button>();
            if (btn != null)
                btn.interactable = true;
        }
    }

    public void EndChangeLevel()
    {
        if (counter == 4)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            return ;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //GameDifficulty = (GameDifficulty)PlayerPrefs.GetInt("GameDifficulty", 1);
        changer.SetDifficulty();
        GameDifficulty = GameState.CurrentDifficulty;

        roundedchange = changeamount
            .Select(p => Mathf.RoundToInt(p))
            .ToList();

        SelectRandomChange();

        UIManager.ChangeSceneText();
    }

    public void ResetChangeLvl()
    {
        successpanel.SetActive(false);
        counter += 1;
        SelectRandomChange();
        UnlockChangeBtn();
        Debug.Log("Change reset");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
public static class GameState
{
    public static GameDifficulty CurrentDifficulty;
}
