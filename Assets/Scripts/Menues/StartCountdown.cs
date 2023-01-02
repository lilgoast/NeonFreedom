using System.Collections;
using TMPro;
using UnityEngine;

public class StartCountdown : MonoBehaviour
{
    public GameObject countdownPanel;

    private TextMeshProUGUI countdown;

    void Start()
    {
        countdown = countdownPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        Time.timeScale = 0f;
        GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().Pause(); 
        StartCoroutine(Countdown());
    }

    public IEnumerator Countdown()
    {
        countdownPanel.SetActive(true);
        float startTime = Time.realtimeSinceStartup;
        PauseMenu.isCountingDown = true;
        while (Time.realtimeSinceStartup - startTime < 3)
        {
            if (Time.realtimeSinceStartup - startTime > 2)
                countdown.text = "1";
            else if (Time.realtimeSinceStartup - startTime > 1)
                countdown.text = "2";
            else
                countdown.text = "3";
            yield return null;
        }
        countdown.text = "";
        countdownPanel.SetActive(false);
        PauseMenu.isCountingDown = false;
        Time.timeScale = 1f;
        GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().Play();
    }
}
