using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrSoundButton : MonoBehaviour
{
    public Sprite soundOnSprite;
    public Sprite soundOffSprite;
    Image image;
    [HideInInspector]
    public bool soundIsOn;
    // Start is called before the first frame update
    void Awake()
    {

        image = GetComponent<Image>();
        if (PlayerPrefs.GetInt("SoundIsOn") == 1)
        {
            image.sprite = soundOnSprite;
            soundIsOn = true;
        }
        else if (PlayerPrefs.GetInt("SoundIsOn") == 0)
        {
            image.sprite = soundOffSprite;
            soundIsOn = false;
        }
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt("SoundIsOn") == 1)
        {
            image.sprite = soundOnSprite;
            soundIsOn = true; 
        }
        else if (PlayerPrefs.GetInt("SoundIsOn") == 0)
        {
            image.sprite = soundOffSprite;
            soundIsOn = false;
        }
    }

    public void ChangeState()
    {
        soundIsOn = !soundIsOn;
        if (soundIsOn)
        {
            image.sprite = soundOnSprite;
            PlayerPrefs.SetInt("SoundIsOn", 1);
        }
        else
        {
            image.sprite = soundOffSprite;
            PlayerPrefs.SetInt("SoundIsOn", 0);
        }
    }
}
