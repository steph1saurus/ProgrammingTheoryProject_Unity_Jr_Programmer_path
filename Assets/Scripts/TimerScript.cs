using System.Collections;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float currentTime = 90f;
    [SerializeField] TextMeshProUGUI countdownText;
    public MainManager mainManagerScript;

    void Start()
    {
        StartCoroutine(Countdown(3));
        
    }

    IEnumerator Countdown(int seconds)
    {
        int count = seconds;

        while (count > 0)
        {
            countdownText.text = count.ToString();
            yield return new WaitForSeconds(1);
            count--;
        }

        countdownText.text = "Go!";
        yield return new WaitForSeconds(1);

        countdownText.gameObject.SetActive(false); // Hide the countdown text after countdown finishes
        MainManager.gameActive = true;
        
    }

    private void Update()
    {
        if (MainManager.gameActive)
        {
            StartTimer();
        }
    }

    void StartTimer()
    {
        if (currentTime >=0)
        { 
        currentTime -= Time.deltaTime;
        
        SetTimerText();
        }

        else if (currentTime <=0)
        mainManagerScript.GameOver();
    
       
    }

    private void SetTimerText()
    {
        timerText.text = currentTime.ToString("0.0"); // Round the time to nearest integer

        if (currentTime <= 10)
        {
            timerText.color = Color.red;
        }

       
    }
}
