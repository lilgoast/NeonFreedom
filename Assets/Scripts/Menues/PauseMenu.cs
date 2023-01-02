using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public static bool isPaused;
    public GameObject countdownPanel; 
    public static bool isCountingDown;

    private TextMeshProUGUI countdown;

    void Start()
    {
        countdown = countdownPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !isCountingDown)
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }

        if(isCountingDown)
        {
            GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().Pause();
        }
    }

    public void ResumeButton()
    {
        ResumeGame();
    }    
    
    public void MainMenuButton()
    {
        ClosePauseMenu();
        SceneManager.LoadScene("MainMenu");
    }    
    
    public void RestartButton()
    {
        ClosePauseMenu();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OptionsButton()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void BackButton()
    {
        optionsMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }


    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().Pause();
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
        StartCoroutine(WaitAfterUnpause());
    }

    private void ClosePauseMenu()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    private IEnumerator WaitAfterUnpause()
    {
        countdownPanel.SetActive(true);
        float startTime = Time.realtimeSinceStartup;
        isCountingDown = true;
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
        Time.timeScale = 1f;
        isPaused = false;
        isCountingDown = false;
        GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().Play();
    }
}
