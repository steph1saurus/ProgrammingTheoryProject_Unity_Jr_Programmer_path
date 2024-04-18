using System.Collections;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float currentTime = 90f;
    [SerializeField] TextMeshProUGUI countdownText;
    [SerializeField] bool gameActive;

    void Start()
    {
        StartCoroutine(Countdown(3));
        gameActive = false;
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
        gameActive = true;
    }

    private void Update()
    {
        if (gameActive)
        {
            StartTimer();
        }
    }

    void StartTimer()
    {
        currentTime -= Time.deltaTime;
        SetTimerText();
    }

    private void SetTimerText()
    {
        timerText.text = currentTime.ToString("0.0"); // Round the time to nearest integer

        if (currentTime <= 10)
        {
            timerText.color = Color.red;
        }

        if (currentTime <= 0)
        {
            timerText.text = "0.0";
            enabled = false;
        }
    }
}
