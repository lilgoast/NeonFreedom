using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UIElements;

public class LetterMovement : MonoBehaviour
{
    [SerializeField] GameObject letterK;
    [SerializeField] GameObject letterJ;
    [SerializeField] float SongBMP = 100f;

    private GameObject K;
    private GameObject J;
    private Transform parent;
    private float oneBeatTime;
    private float timePassed = 0;
    private bool letterChanger;

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
        if(Input.GetKeyDown(KeyCode.K) && K.activeSelf)
        {
            K.SetActive(false);
            Score.score += 5;
        }

        if (Input.GetKeyDown(KeyCode.J) && J.activeSelf)
        {
            J.SetActive(false);
            Score.score += 5;
        }

        timePassed += Time.deltaTime;

        if(timePassed >= oneBeatTime)
        {
            if (letterChanger)
            {
                K.SetActive(true);
                J.SetActive(false);
            }
            else
            {
                K.SetActive(false);
                J.SetActive(true);
            }

            letterChanger = !letterChanger;
            timePassed = 0;
        }
    }
}
