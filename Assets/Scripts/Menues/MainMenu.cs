using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject optionsMenu;
    [SerializeField] Animator animator;

    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void Options()
    {
        animator.Play("GoToOptions", 0, 0.0f);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
