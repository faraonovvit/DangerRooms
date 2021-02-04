using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScrMainMenuController : MonoBehaviour
{
    void Start()
    {
        //���������
        if (!PlayerPrefs.HasKey("InputType"))
        {
            PlayerPrefs.SetString("InputType", "Joystick");
        }
        //���������� �������
        if (!PlayerPrefs.HasKey("LevelCount"))
        {
            PlayerPrefs.SetInt("LevelCount", 1);
        }
        //������� �� ���� 1 - true 0 - false
        if (!PlayerPrefs.HasKey("SoundIsOn"))
        {
            PlayerPrefs.SetInt("SoundIsOn", 0);
        }
        //�������� �� ������  1 - true 0 - false
        if (!PlayerPrefs.HasKey("MusicIsOn"))
        {
            PlayerPrefs.SetInt("MusicIsOn", 0);
        }
        GameObject.FindGameObjectWithTag("Music").GetComponent<ScrMusicPlayer>().PlayMenuMusic();
    }
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    //���� ����������
    public void ExitGame()
    {
        Application.Quit();
    }
}
