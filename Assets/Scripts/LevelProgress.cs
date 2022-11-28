using UnityEngine;
using UnityEngine.UI;

public class LevelProgress : MonoBehaviour
{
    private Slider levelProgressSlider;
    private float songLength;

    private void Start()
    {
        levelProgressSlider = GetComponentInChildren<Slider>();
        songLength = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().clip.length;
        levelProgressSlider.maxValue = songLength;
    }

    void Update()
    {
        levelProgressSlider.value += Time.deltaTime;
    }
}
