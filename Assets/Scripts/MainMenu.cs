using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Game");
    }
    public void Options()
    {
        SceneManager.LoadScene("Options");
    }    
    public void Quit()
    {
        Application.Quit();
    }
}
