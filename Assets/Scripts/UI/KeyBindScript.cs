using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyBindScript : MonoBehaviour
{

    public TextMeshProUGUI buttonLeft, buttonRight;
    public Color selected = new(255, 255, 255, 128);

    private Color normal = new(0, 0, 0, 128);
    private GameObject currentKey;
    private readonly Dictionary<string, KeyCode> keyBinds = new();
    private RhythmTapping rhythmTapping;
    private bool rtExist;

    void Start()
    {
        try
        {
            rhythmTapping = GameObject.FindGameObjectWithTag("RhythmTapping").GetComponent<RhythmTapping>();
            rtExist = true;
        }
        catch { 
            Debug.Log("RhythmTapping is don't exist");
            rtExist = false;
        }

        keyBinds.Add("ButtonLeft",(KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("ButtonLeft", "J")));
        keyBinds.Add("ButtonRight",(KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("ButtonRight", "K")));

        buttonLeft.text = keyBinds["ButtonLeft"].ToString();
        buttonRight.text = keyBinds["ButtonRight"].ToString();
    }

    private void OnGUI()
    {
       if(currentKey != null)
        {
            Event e = Event.current;

            if (e.isKey)
            {
                keyBinds[currentKey.name] = e.keyCode;
                currentKey.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = e.keyCode.ToString();
                currentKey.GetComponent<Image>().color = normal;
                currentKey = null;
                SaveKeyBinds();
                
                if(rtExist)
                    rhythmTapping.ChangeKeys();
            }
        }
    }

    public void ChangeKey(GameObject clicked)
    {
        if (currentKey != null)
        {
            currentKey.GetComponent<Image>().color = normal;
        }

        currentKey = clicked;
        normal = currentKey.GetComponent<Image>().color;
        currentKey.GetComponent<Image>().color = selected;
    }

    public void SaveKeyBinds()
    {
        foreach(var keyBind in keyBinds)
        {
            PlayerPrefs.SetString(keyBind.Key, keyBind.Value.ToString());
        }

        PlayerPrefs.Save();
    }
}
