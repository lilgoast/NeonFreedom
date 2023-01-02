using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RhythmTapping : MonoBehaviour
{
    [SerializeField] GameObject letterLeftPanel;
    [SerializeField] GameObject letterRightPanel;
    [SerializeField] ParticleSystem tapMissParticleLeft;
    [SerializeField] ParticleSystem tapHitParticleLeft;
    [SerializeField] ParticleSystem tapMissParticleRight;
    [SerializeField] ParticleSystem tapHitParticleRight;

    private GameObject objectLetterRight;
    private GameObject objectLetterLeft;
    private Transform parent;
    private float oneBeatTime;
    private float timePassedFromLastLoop = 0;
    private bool letterChanger;
    private bool tapHitted, tapMissed;
    private KeyCode leftLetterCode;
    private KeyCode rightLetterCode;

    void Start()
    {
        oneBeatTime = 60 / SongBPM.BPM;

        parent = GetComponent<Transform>();

        objectLetterRight = Instantiate(letterRightPanel, parent);
        objectLetterLeft = Instantiate(letterLeftPanel, parent);

        objectLetterRight.SetActive(true);
        objectLetterLeft.SetActive(false);
        ChangeKeys();
    }

    private void Update()
    {
        if (!tapHitted && !tapMissed && !PauseMenu.isPaused)
        {
            if (Input.GetKeyDown(rightLetterCode))
            {
                if (objectLetterLeft.activeSelf)
                {
                    tapMissed = true;
                }
                else
                {
                    objectLetterRight.SetActive(false);
                    RegisterHit();
                }
            }
            else if (Input.GetKeyDown(leftLetterCode))
            {
                if (objectLetterRight.activeSelf)
                {
                    tapMissed = true;
                }
                else
                {
                    objectLetterLeft.SetActive(false);
                    RegisterHit();
                }
            }
        }

        if (timePassedFromLastLoop >= oneBeatTime)
        {
            if (letterChanger)
            {
                objectLetterRight.SetActive(true);
                objectLetterLeft.SetActive(false);

                if (!tapHitted || tapMissed)
                    tapMissParticleLeft.Play();
                else
                    tapHitParticleLeft.Play();
            }
            else
            {
                objectLetterRight.SetActive(false);
                objectLetterLeft.SetActive(true);

                if (!tapHitted || tapMissed)
                    tapMissParticleRight.Play();
                else
                    tapHitParticleRight.Play();
            }

            letterChanger = !letterChanger;
            timePassedFromLastLoop = 0;
            tapHitted = false;
            tapMissed = false;
        }

        timePassedFromLastLoop += Time.deltaTime;
    }

    private void RegisterHit()
    {
        Score.AddScore(5);
        tapHitted = true;
    }

    public void ChangeKeys()
    {
        objectLetterLeft.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetString("ButtonLeft", "J");
        objectLetterRight.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetString("ButtonRight", "K");
        leftLetterCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("ButtonLeft", "J"));
        rightLetterCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("ButtonRight", "K"));
    }
}
