using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgress : MonoBehaviour
{
    private Slider levelProgressSlider;
    private GameObject music;
    private float songLength;
    private float timePassed;

    private void Start()
    {
        timePassed = 0;
        levelProgressSlider = GetComponentInChildren<Slider>();
        music = GameObject.FindGameObjectWithTag("Music");
        songLength = music.GetComponent<AudioSource>().clip.length;
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
