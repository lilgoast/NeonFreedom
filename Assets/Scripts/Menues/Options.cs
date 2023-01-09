using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject optionsMenu;
    [SerializeField] Animator animator;

    public AudioMixer audioMixer;
    private void Start()
    {
        audioMixer.SetFloat("volume", PlayerPrefs.GetFloat("gameVolume", 0));
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("gameVolume", volume);
    }

    public void Back()
    {
        animator.Play("GoToMainMenuFromOptions", 0, 0.0f);
    }
}
