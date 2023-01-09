using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject optionsMenu;
    [SerializeField] GameObject playMenu;
    [SerializeField] Animator animator;

    public void Play()
    {
        animator.Play("GoToPlayMenu", 0, 0.0f);
        playMenu.SetActive(true);
        //SceneManager.LoadScene("Game");
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
