using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
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
        SceneManager.LoadScene("MainMenu");
    }
}
