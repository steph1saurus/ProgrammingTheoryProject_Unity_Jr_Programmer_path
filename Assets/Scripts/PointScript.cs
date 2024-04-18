using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointScript : MonoBehaviour
{
    [SerializeField] int point = 1;
    [SerializeField] int score;
    [SerializeField] TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

  
    private void OnTriggerEnter(Collider other)
    {
        UpdateScore();   
    }

    void UpdateScore()
    {
        score += point;
        scoreText.text = "Score: " + score;
    }
}
