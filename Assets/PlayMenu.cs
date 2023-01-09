using System;
using System.Collections;
using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayMenu : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject playMenu;
    [SerializeField] RawImage rawImage;
    [SerializeField] TextMeshProUGUI songName;
    [SerializeField] TextMeshProUGUI artistName;
    [SerializeField] TextMeshProUGUI durationText;

    private void Start()
    {
        using (WebClient client = new WebClient())
        {
            client.DownloadFile(new Uri("https://img.youtube.com/vi/plnfIj7dkJE/maxresdefault.jpg"), @"Assets/Images/image.png");
        }
    }

    public void Back()
    {
        animator.Play("GoToMainMenuFromPlayMenu", 0, 0.0f);
        StartCoroutine(DisableMenuAfterAnimation());
    }

    IEnumerator DisableMenuAfterAnimation()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        playMenu.SetActive(false);
    }

    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    private void LoadPanel()
    {

    }
}