using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSongBPM : MonoBehaviour
{
    [SerializeField] float BPMReducer = 1f;
    void Awake()
    {
        float bpm = UniBpmAnalyzer.AnalyzeBpm(GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().clip);
        SongBPM.BPM = bpm / BPMReducer;
        Debug.Log("BPM: " + bpm + " | Reduced BPM: " + SongBPM.BPM);
    }
}
