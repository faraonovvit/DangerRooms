using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrMusicButton : MonoBehaviour
{
    public Sprite musicOnSprite;
    public Sprite musicOffSprite;
    Image image;
    ScrMusicPlayer audioSource;
    [HideInInspector]
    public bool musicIsOn;
    // Start is called before the first frame update
    void Awake()
    {
        GameObject musicPlayer = GameObject.FindGameObjectWithTag("Music");
        if (musicPlayer != null)
            audioSource = musicPlayer.GetComponent<ScrMusicPlayer>();
        image = GetComponent<Image>();
        if (PlayerPrefs.GetInt("MusicIsOn") == 1)
        {
            image.sprite = musicOnSprite;
            musicIsOn = true;
        }
        else if (PlayerPrefs.GetInt("MusicIsOn") == 0)
        {
            image.sprite = musicOffSprite;
            musicIsOn = false;
        }
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt("MusicIsOn") == 1)
        {
            image.sprite = musicOnSprite;
            musicIsOn = true;
        }
        else if (PlayerPrefs.GetInt("MusicIsOn") == 0)
        {
            image.sprite = musicOffSprite;
            musicIsOn = false;
        }
    }

    public void ChangeState()
    {

        musicIsOn = !musicIsOn;
        if (musicIsOn)
        {
            image.sprite = musicOnSprite;
            PlayerPrefs.SetInt("MusicIsOn", 1);
            audioSource.TurnOnMusic();
        }
        else
        {
            image.sprite = musicOffSprite;
            PlayerPrefs.SetInt("MusicIsOn", 0);
            audioSource.TurnOffMusic();
        }
    }
}
