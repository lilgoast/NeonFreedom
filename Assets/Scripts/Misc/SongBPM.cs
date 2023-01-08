using UnityEngine;

public class SongBPM : MonoBehaviour
{
    private static float bpm;

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
