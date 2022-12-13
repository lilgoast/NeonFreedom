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
    [SerializeField] GameObject StopPanel;
    [SerializeField] float SongBMP = 100f;

    private GameObject K;
    private GameObject J;
    private GameObject SP;
    private Transform parent;
    private RectTransform rectTransformK;
    private RectTransform rectTransformJ;
    private float moved = 0;
    private Vector3 startVector;
    private float oneBeatTime;
    private bool letterChanger = true;
    private float newPosition;

    void Start()
    {
        oneBeatTime = 60 / SongBMP;
        parent = GetComponent<Transform>();
        SP = Instantiate(StopPanel, parent);
        K = Instantiate(letterK, parent);
        J = Instantiate(letterJ, parent);
        rectTransformK = K.GetComponent<RectTransform>();
        rectTransformJ = J.GetComponent<RectTransform>();
        startVector = rectTransformK.localPosition;
        K.SetActive(true);
        J.SetActive(false);

        SP.GetComponent<RectTransform>().localPosition = new Vector3(0, Screen.currentResolution.width / 2 * oneBeatTime, 0);
    }

    private void Update()
    {

        if (moved < oneBeatTime + (oneBeatTime / 10))
        {
            newPosition = Screen.currentResolution.width / 2 * Time.deltaTime;

            if (letterChanger)
            {
                rectTransformK.localPosition -= new Vector3(newPosition, 0, 0);
                if(Input.GetKeyDown(KeyCode.K))
                {
                    if(moved < oneBeatTime + (oneBeatTime / 10) && moved > oneBeatTime - (oneBeatTime / 10))
                    {
                        Score.score += 5;
                    }
                    K.SetActive(false);
                }
            }
            else
            {
                rectTransformJ.localPosition -= new Vector3(newPosition, 0, 0);
                if (Input.GetKeyDown(KeyCode.J))
                {
                    if (moved < oneBeatTime + (oneBeatTime / 10) && moved > oneBeatTime - (oneBeatTime / 10))
                    {
                        Score.score += 5;
                    }
                    J.SetActive(false);
                }
            }
            moved += Time.deltaTime;
        }
        else
        {
            if (letterChanger)
            {
                K.SetActive(false);
                J.SetActive(true);
            }
            else
            {
                K.SetActive(true);
                J.SetActive(false);
            }

            letterChanger = !letterChanger;

            rectTransformJ.localPosition = startVector;
            rectTransformK.localPosition = startVector;
            moved = 0;
        }

    }
}
