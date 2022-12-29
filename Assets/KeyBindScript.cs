using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyBindScript : MonoBehaviour
{

    public TextMeshProUGUI buttonLeft, buttonRight;

    private GameObject currentKey;
    private Color32 normal = new(0, 0, 0, 128);
    private Color32 selected = new(255, 255, 255, 128);
    private readonly Dictionary<string, KeyCode> keyBinds = new();
    private RhythmTapping rhythmTapping;

    void Start()
    {
        rhythmTapping = GameObject.FindGameObjectWithTag("RhythmTapping").GetComponent<RhythmTapping>();

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

            if(e.isKey)
            {
                keyBinds[currentKey.name] = e.keyCode;
                currentKey.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = e.keyCode.ToString();
                currentKey.GetComponent<Image>().color = normal;
                currentKey = null;
                SaveKeyBinds();
                rhythmTapping.ChangeKeys();
            }
        }
    }

    public void ChangeKey(GameObject clicked)
    {
        if(currentKey != null)
        {
            currentKey.GetComponent<Image>().color = normal;
        }

        currentKey = clicked;
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
