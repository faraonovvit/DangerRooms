using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ScrLevelChooseMenuController : MonoBehaviour
{
    GameObject[] levelButtons;

    // Start is called before the first frame update
    void Start()
    {
        levelButtons = GameObject.FindGameObjectsWithTag("LevelButton");
        int levelCount = levelButtons.Length;
        //Количество уровней
        if (PlayerPrefs.GetInt("LevelCount") != levelCount)
        {
            PlayerPrefs.SetInt("LevelCount", levelCount);
        }
        //Уровни доступны или нет
        if (!PlayerPrefs.HasKey("Level1Unlocked"))
            PlayerPrefs.SetInt("Level1Unlocked", 1);

        if (!PlayerPrefs.HasKey("Level1FinishStar"))
            PlayerPrefs.SetInt("Level1FinishStar", 0);

        if (!PlayerPrefs.HasKey("Level1FinishInTimeStar"))
            PlayerPrefs.SetInt("Level1FinishInTimeStar", 0);

        if (!PlayerPrefs.HasKey("Level1FindStar"))
            PlayerPrefs.SetInt("Level1FindStar", 0);

        for (int i = 2; i <= levelCount; i++)
        {
            if (!PlayerPrefs.HasKey("Level" + i.ToString() + "Unlocked"))
            {
                PlayerPrefs.SetInt("Level" + i.ToString() + "Unlocked", 0);
            }

            if (!PlayerPrefs.HasKey("Level" + i.ToString() + "FinishStar"))
                PlayerPrefs.SetInt("Level" + i.ToString() + "FinishStar", 0);

            if (!PlayerPrefs.HasKey("Level" + i.ToString() + "FinishInTimeStar"))
                PlayerPrefs.SetInt("Level" + i.ToString() + "FinishInTimeStar", 0);

            if (!PlayerPrefs.HasKey("Level" + i.ToString() + "FindStar"))
                PlayerPrefs.SetInt("Level" + i.ToString() + "FindStar", 0);
        }


        for (int i = 0; i < levelCount; i++)
        {
            if (PlayerPrefs.GetInt("Level" + (i + 1).ToString() + "Unlocked") == 1)
            {
                GameObject levelI = null;
                foreach (GameObject levelButton in levelButtons)
                    if (levelButton.GetComponent<ScrLevelButton>().text.text == (i + 1).ToString())
                        levelI = levelButton;
                if (levelI != null)
                    levelI.GetComponent<ScrLevelButton>().ChangeState(true);
                else
                    Debug.Log("Такого уровня нет");
            }
            else if (PlayerPrefs.GetInt("Level" + (i + 1).ToString() + "Unlocked") == 0)
            {
                GameObject levelI = null;
                foreach (GameObject levelButton in levelButtons)
                    if (levelButton.GetComponent<ScrLevelButton>().text.text == (i + 1).ToString())
                        levelI = levelButton;
                if (levelI != null)
                    levelI.GetComponent<ScrLevelButton>().ChangeState(false);
                else
                    Debug.Log("Такого уровня нет");
            }
        }
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    //Пока бесполезна
    public void ExitGame()
    {
        Application.Quit();
    }
}
