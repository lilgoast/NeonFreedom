using UnityEngine;

public class SongBPM : MonoBehaviour
{
    [SerializeField] float setSongBPM;

    private static float bpm;

    private void Start()
    {
        BPM = setSongBPM;
    }

    public static float BPM
    {
        get { return bpm; }
        set
        {
            if(value < 0)
            {
                value = 0;
            }
            bpm = value;
        }
    }
}
