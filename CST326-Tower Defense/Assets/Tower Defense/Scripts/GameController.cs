using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Button startButton;
    public Button restartButton;

    private void Awake()
    {
        Time.timeScale = 0f;
    }
    public void StartGame()
    {
        Time.timeScale = 1f;
        startButton.gameObject.SetActive(false);
    }

    public void ShowRestart()
    {
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

}
