using UnityEngine;
using UnityEngine.UI;

public class LevelProgress : MonoBehaviour
{
    private Slider levelProgressSlider;
    private float songLength;
    private float timePassed;

    private void Start()
    {
        timePassed = 0;
        levelProgressSlider = GetComponentInChildren<Slider>();
        songLength = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().clip.length;
        levelProgressSlider.maxValue = songLength;
    }

    void Update()
    {
        if(timePassed < songLength)
        {
            levelProgressSlider.value = timePassed;
            timePassed += Time.deltaTime;
        }
    }
}
