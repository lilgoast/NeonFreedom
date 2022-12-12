using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UIElements;

public class LetterMovement : MonoBehaviour
{
    [SerializeField] GameObject letterF;
    [SerializeField] GameObject letterJ;
    [SerializeField] float SongBMP = 100f;

    private GameObject F;
    private GameObject J;
    private Transform parent;
    private RectTransform rectTransformF;
    private RectTransform rectTransformJ;
    private float moved = 0;
    private Vector3 startVector;
    private float oneBeatTime;
    private bool letterChanger = true;

    void Start()
    {
        oneBeatTime = 60 / SongBMP;
        parent = GetComponent<Transform>();
        F = Instantiate(letterF, parent);
        J = Instantiate(letterJ, parent);
        rectTransformF = F.GetComponent<RectTransform>();
        rectTransformJ = J.GetComponent<RectTransform>();
        startVector = rectTransformF.localPosition;
        F.SetActive(false);
        J.SetActive(true);
    }

    private void Update()
    {
        if (moved <= oneBeatTime)
        {
            if(letterChanger)
            {
                rectTransformF.localPosition -= new Vector3(700 * Time.deltaTime, 0, 0);
            }
            else
            {
                rectTransformJ.localPosition -= new Vector3(700 * Time.deltaTime, 0, 0);
            }
            moved += Time.deltaTime;
        }
        else
        {
            if (letterChanger)
            {
                F.SetActive(false);
                J.SetActive(true);
            }
            else
            {
                F.SetActive(true);
                J.SetActive(false);
            }
            letterChanger = !letterChanger;
            rectTransformJ.localPosition = startVector;
            rectTransformF.localPosition = startVector;
            moved = 0;
            Debug.Log(oneBeatTime);
        }

    }
}
