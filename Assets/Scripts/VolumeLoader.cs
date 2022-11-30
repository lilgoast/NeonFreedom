using UnityEngine;
using UnityEngine.UI;

public class VolumeLoader : MonoBehaviour
{
    void Start()
    {
        GetComponent<Slider>().value = PlayerPrefs.GetFloat("gameVolume", 0);
    }
}
