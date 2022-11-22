using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] TextMeshProUGUI MultiplierText;
    [SerializeField] int loopToMiltiply = 5;

    private int loopsPassed;
    private int score;
    private int scoreMultiplier;
    private float idleTime;
    private float tempIdleTime;

    void Start()
    {
        tempIdleTime = 0;
        loopsPassed = 0;
        score = 0;
        ScoreText.text = score.ToString();
    }

    private void Update()
    {
        idleTime = LoopLoader.idleTime;
        tempIdleTime += Time.deltaTime;

        if(tempIdleTime >= idleTime && scoreMultiplier > 0)
        {
            scoreMultiplier--;
            tempIdleTime = 0;
            loopsPassed = 0;
        }

        if (scoreMultiplier > 0)
            MultiplierText.text = "x" + scoreMultiplier;
        else
            MultiplierText.text = "";
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Loop")
        {
            tempIdleTime = 0;
            ScoreText.text = (score += scoreMultiplier).ToString();
            loopsPassed++;
            if (loopsPassed == loopToMiltiply)
            {
                if(scoreMultiplier < 7)
                    scoreMultiplier++;
                loopsPassed = 0;
            }
        }
    }

}
