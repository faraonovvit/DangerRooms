using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScrSettingsMenuController : MonoBehaviour
{
    public GameObject buttonFixedLeft;
    public GameObject buttonFixedRight;
    public GameObject buttonFloating;
    public Sprite buttonSelected;
    public Sprite buttonNotSelected;
    public GameObject resetImage;

    void Start()
    {
        string type = PlayerPrefs.GetString("JoystickType");
        if (type == "FixedLeft")
        {
            buttonFixedLeft.GetComponent<Image>().sprite = buttonSelected;
            buttonFixedRight.GetComponent<Image>().sprite = buttonNotSelected;
            buttonFloating.GetComponent<Image>().sprite = buttonNotSelected;
        }
        else if (type == "FixedRight")
        {
            buttonFixedRight.GetComponent<Image>().sprite = buttonSelected;
            buttonFixedLeft.GetComponent<Image>().sprite = buttonNotSelected;
            buttonFloating.GetComponent<Image>().sprite = buttonNotSelected;
        }
        else if (type == "Floating")
        {
            buttonFloating.GetComponent<Image>().sprite = buttonSelected;
            buttonFixedLeft.GetComponent<Image>().sprite = buttonNotSelected;
            buttonFixedRight.GetComponent<Image>().sprite = buttonNotSelected;
        }
    }

    public void ChangeJoystickType(string type)
    {
        PlayerPrefs.SetString("JoystickType", type);
        if (type == "FixedLeft")
        {
            buttonFixedLeft.GetComponent<Image>().sprite = buttonSelected;
            buttonFixedRight.GetComponent<Image>().sprite = buttonNotSelected;
            buttonFloating.GetComponent<Image>().sprite = buttonNotSelected;
        }
        else if (type == "FixedRight")
        {
            buttonFixedRight.GetComponent<Image>().sprite = buttonSelected;
            buttonFixedLeft.GetComponent<Image>().sprite = buttonNotSelected;
            buttonFloating.GetComponent<Image>().sprite = buttonNotSelected;
        }
        else if (type == "Floating")
        {
            buttonFloating.GetComponent<Image>().sprite = buttonSelected;
            buttonFixedLeft.GetComponent<Image>().sprite = buttonNotSelected;
            buttonFixedRight.GetComponent<Image>().sprite = buttonNotSelected;
        }
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ResetProgress()
    {
        int levelCount = 10;
        PlayerPrefs.DeleteAll();
        //Тип управления (джойстик или кнопки)
        PlayerPrefs.SetString("JoystickType", "FixedLeft");
        buttonFixedLeft.GetComponent<Image>().sprite = buttonSelected;
        buttonFixedRight.GetComponent<Image>().sprite = buttonNotSelected;
        buttonFloating.GetComponent<Image>().sprite = buttonNotSelected;
        //Количество уровней
        PlayerPrefs.SetInt("LevelCount", levelCount);
        //Включен ли звук 1 - true 0 - false
        PlayerPrefs.SetInt("SoundIsOn", 1);
        //Включена ли музыка  1 - true 0 - false
        PlayerPrefs.SetInt("MusicIsOn", 1);
        //Открыты ли уровни
        PlayerPrefs.SetInt("Level1Unlocked", 1);
        PlayerPrefs.SetInt("Level1FinishStar", 0);
        PlayerPrefs.SetInt("Level1FinishInTimeStar", 0);
        PlayerPrefs.SetInt("Level1FindStar", 0);

        for (int i = 2; i <= 10; i++)
        {
            PlayerPrefs.SetInt("Level" + i.ToString() + "Unlocked", 0);
            PlayerPrefs.SetInt("Level" + i.ToString() + "FinishStar", 0);
            PlayerPrefs.SetInt("Level" + i.ToString() + "FinishInTimeStar", 0);
            PlayerPrefs.SetInt("Level" + i.ToString() + "FindStar", 0);
        }

        resetImage.SetActive(true);
    }


}
