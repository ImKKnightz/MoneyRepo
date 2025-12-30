using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static ChangeManager;

public class SceneChanger : MonoBehaviour
{
    public GameDifficulty GameDifficulty;

    public void Level1()
    {
        SceneManager.LoadScene(1);
    }

    public void Level2()
    {
        SceneManager.LoadScene(2);
    }

    public void Level3()
    {
        SceneManager.LoadScene(3);
    }

    public void Level4()
    {
        SceneManager.LoadScene(4);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadLevel(int difficulty)
    {
        SceneManager.LoadScene("Level1");
        PlayerPrefs.SetInt("GameDifficulty", difficulty);
    }

    public void SetDifficulty()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        switch (sceneName)
        {
            case "PaymentRounded":
                GameState.CurrentDifficulty = GameDifficulty.Level1;
                break;

            case "Payment":
                GameState.CurrentDifficulty = GameDifficulty.Level2;
                break;

            case "ChangeRounded":
                GameState.CurrentDifficulty = GameDifficulty.Level1;
                break;

            case "Change":
                GameState.CurrentDifficulty = GameDifficulty.Level2;
                break;

            default:
                GameState.CurrentDifficulty = GameDifficulty.Level1;
                break;
        }
    }
}
