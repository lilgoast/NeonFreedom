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
    public TextMeshProUGUI coundown;

    public static bool isCountingDown;

    void Start()
    {
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
    }

    public void ResumeButton()
    {
        ResumeGame();
    }    
    
    public void MainMenuButton()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene("MainMenu");
    }    
    
    public void RestartButton()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
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

    private IEnumerator WaitAfterUnpause()
    {
        float startTime = Time.realtimeSinceStartup;
        isCountingDown = true;
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
        Time.timeScale = 1f;
        isPaused = false;
        isCountingDown = false;
        GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().Play();
    }
}
