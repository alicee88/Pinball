using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    int score = 0;
    TextMeshProUGUI scoreText;
    

    // Start is called before the first frame update
    void Start()
    {
        scoreText = FindObjectOfType<TextMeshProUGUI>();
        scoreText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPointsToScore(int points)
    {
        score += points;
        scoreText.text = score.ToString();
    }
}
