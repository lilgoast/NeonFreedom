using System.Collections;
using TMPro;
using UnityEngine;

public class StartCountdown : MonoBehaviour
{
    public TextMeshProUGUI coundown;

    void Start()
    {
        Time.timeScale = 0f;
        GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().Pause(); 
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        float startTime = Time.realtimeSinceStartup;
        PauseMenu.isCountingDown = true;
        while (Time.realtimeSinceStartup - startTime < 3)
        {
            if (Time.realtimeSinceStartup - startTime > 2)
                coundown.text = "1";
            else if (Time.realtimeSinceStartup - startTime > 1)
                coundown.text = "2";
            else
                coundown.text = "3";
            yield return null;
        }
        coundown.text = "";
        PauseMenu.isCountingDown = false;
        Time.timeScale = 1f;
        GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().Play();
    }
}
