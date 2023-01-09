using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TagLib;
using System.IO;
using UnityEngine.UI;
using TMPro;
using System.Text;

public class LoadAudiClip : MonoBehaviour
{
    private static string artist, title;

    public static void ReadMetadata(string path, RawImage rawImage, TextMeshProUGUI artistName, TextMeshProUGUI songName, TextMeshProUGUI durationText)
    {
        var tfile = TagLib.File.Create(path);

        title = tfile.Tag.Title;
        
        foreach(string item in tfile.Tag.Performers)
        {
            artist += item;
        }

        System.TimeSpan duration = tfile.Properties.Duration;
        
        IPicture pic = tfile.Tag.Pictures[0];
        MemoryStream ms = new(pic.Data.Data);
        ms.Seek(0, SeekOrigin.Begin);
        Texture2D tex = new(2, 2);
        tex.LoadImage(ms.ToArray());

        artistName.text = artist;
        songName.text = title;
        durationText.text = $"{duration.Minutes}:{duration.Seconds}";
        rawImage.texture = tex;
    }
}
