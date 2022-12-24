using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmTapping : MonoBehaviour
{
    [SerializeField] GameObject letterK;
    [SerializeField] GameObject letterJ;
    [SerializeField] float SongBMP = 100f;
    [SerializeField] ParticleSystem tapMissParticleJ;
    [SerializeField] ParticleSystem tapHitParticleJ;
    [SerializeField] ParticleSystem tapMissParticleK;
    [SerializeField] ParticleSystem tapHitParticleK;

    private GameObject K;
    private GameObject J;
    private Transform parent;
    private float oneBeatTime;
    private float timePassedFromLastLoop = 0;
    private bool letterChanger;
    private bool tapHitted, tapMissed;

    void Start()
    {
        oneBeatTime = 60 / SongBMP;

        parent = GetComponent<Transform>();

        K = Instantiate(letterK, parent);
        J = Instantiate(letterJ, parent);

        K.SetActive(true);
        J.SetActive(false);
    }

    private void Update()
    {
        if (!tapHitted && !tapMissed && !PauseMenu.isPaused)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                if (J.activeSelf)
                {
                    tapMissed = true;
                }
                else
                {
                    K.SetActive(false);
                    RegisterHit();
                }
            }
            else if (Input.GetKeyDown(KeyCode.J))
            {
                if (K.activeSelf)
                {
                    tapMissed = true;
                }
                else
                {
                    J.SetActive(false);
                    RegisterHit();
                }
            }
        }

        if (timePassedFromLastLoop >= oneBeatTime)
        {
            if (letterChanger)
            {
                K.SetActive(true);
                J.SetActive(false);

                if (!tapHitted || tapMissed)
                    tapMissParticleJ.Play();
                else
                    tapHitParticleJ.Play();
            }
            else
            {
                K.SetActive(false);
                J.SetActive(true);

                if (!tapHitted || tapMissed)
                    tapMissParticleK.Play();
                else
                    tapHitParticleK.Play();
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
}
