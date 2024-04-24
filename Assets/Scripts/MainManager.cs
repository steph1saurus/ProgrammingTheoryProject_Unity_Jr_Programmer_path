using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI countDownText;
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject gameOverText;
    public static bool gameIsPaused;
    public static bool gameActive;

    public TimerScript timerScript;
    

    // Start is called before the first frame update
    void Start()
    {
        gameActive = false; //game will be made active after countdown
        gameIsPaused = false;
    }

   public void GameOver()
    {
        gameActive = false;
        gameOverText.SetActive(true);

        
    }

   public void PauseButtonClicked()
    {
        if (gameIsPaused)
        {
            ResumeGame();
        }
        else
            PauseGame();
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        gameIsPaused = false;
        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        gameIsPaused = true;
        Time.timeScale = 0;
    }


    public void QuitGame()
    {

        Application.Quit();
    }
}
