using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] TextMeshProUGUI MultiplierText;
    [SerializeField] int loopToMiltiply = 5;

    private static int score;
    private int loopsPassed;
    private int scoreMultiplier;
    private float idleTime;
    private float tempIdleTime;

    void Start()
    {
        scoreMultiplier = 1;
        tempIdleTime = 0f;
        loopsPassed = 0;
        score = 0;
        ScoreText.text = score.ToString();
    }

    private void Update()
    {
        ScoreText.text = score.ToString();

        DecreaseMultiplier();

        if (scoreMultiplier > 1)
            MultiplierText.text = "x" + scoreMultiplier;
        else
            MultiplierText.text = "";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Loop"))
        {
            tempIdleTime = 0;

            AddScore(scoreMultiplier);
            ScoreText.text = score.ToString();
            IncreaseMultilier();
        }
    }

    private void DecreaseMultiplier()
    {
        idleTime = LoopLoader.idleTime;
        tempIdleTime += Time.deltaTime;

        if (tempIdleTime >= idleTime && scoreMultiplier > 1)
        {
            scoreMultiplier--;
            tempIdleTime = 0;
            loopsPassed = 0;
        }
    }

    private void IncreaseMultilier()
    {
        loopsPassed++;
        if (loopsPassed == loopToMiltiply)
        {
            if (scoreMultiplier < 7)
                scoreMultiplier++;
            loopsPassed = 0;
        }
    }

    public static void AddScore(int scoreAmount)
    {
        score += scoreAmount;
    }
}
