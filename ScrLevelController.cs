using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ScrLevelController : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject endMenu;
    public Canvas canvas;
    public GameObject infoPanel;
    public int levelNumber;
    public float timerEndValue = 150.0f; //В секундах
    bool openPauseMenu = false;
    bool openEndMenu = false;
    [HideInInspector]
    public bool gameIsPaused;
    [HideInInspector]
    public string joystickType;
    GameObject joystick;

    void Start()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<ScrMusicPlayer>().PlayGameMusic();
        if (Time.timeScale == 0.0f)
            Time.timeScale = 1.0f;
        gameIsPaused = false;
        joystick = GameObject.FindGameObjectWithTag("Joystick");
        RectTransform joystcikHandle = GameObject.FindGameObjectWithTag("JoystickHandle").GetComponent<RectTransform>();
        joystickType = PlayerPrefs.GetString("JoystickType");
        if (joystickType == "FixedLeft")
        {
            joystick.GetComponent<VariableJoystick>().SetMode(JoystickType.Fixed);
            joystcikHandle.anchorMax = new Vector2(0.0f, 0.0f);
            joystcikHandle.anchorMin = new Vector2(0.0f, 0.0f);
            joystcikHandle.anchoredPosition = new Vector2(350.0f, joystcikHandle.anchoredPosition.y);
        }
        else if (joystickType == "FixedRight")
        {
            joystick.GetComponent<VariableJoystick>().SetMode(JoystickType.Fixed);
            joystcikHandle.anchorMax = new Vector2(1.0f, 0.0f);
            joystcikHandle.anchorMin = new Vector2(1.0f, 0.0f);
            joystcikHandle.anchoredPosition = new Vector2(-350.0f, joystcikHandle.anchoredPosition.y);
        }
        else if (joystickType == "Floating")
        {
            joystick.GetComponent<VariableJoystick>().SetMode(JoystickType.Floating);
        }

        if (PlayerPrefs.GetInt("Level" + levelNumber.ToString() + "FindStar") == 1)
        {
            infoPanel.GetComponent<ScrInfoPanel>().star.sprite = infoPanel.GetComponent<ScrInfoPanel>().starSprite;
            Destroy(GameObject.FindGameObjectWithTag("Star"));
        }
        else if (PlayerPrefs.GetInt("Level" + levelNumber.ToString() + "FindStar") == 0)
        {
            infoPanel.GetComponent<ScrInfoPanel>().star.sprite = infoPanel.GetComponent<ScrInfoPanel>().noStarSprite;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ChangeStateMenu("PauseMenu");
            //Debug.Log(Event.current.mousePosition);
        }
    }

    public void ChangeStateMenu(string name)
    {
        if (name == "PauseMenu")
        {
            if (!openEndMenu)
            {
                gameIsPaused = !gameIsPaused;
                openPauseMenu = !openPauseMenu;

                RectTransform menuRectTransform = pauseMenu.GetComponent<RectTransform>();
                if (openPauseMenu)
                {
                    menuRectTransform.localPosition = new Vector3(menuRectTransform.localPosition.x, menuRectTransform.localPosition.y - 800.0f, menuRectTransform.localPosition.z); ;
                    Time.timeScale = 0.0f;
                    joystick.GetComponent<VariableJoystick>().ResetJoystick();
                }
                else
                {
                    menuRectTransform.localPosition = new Vector3(menuRectTransform.localPosition.x, menuRectTransform.localPosition.y + 800.0f, menuRectTransform.localPosition.z);
                    Time.timeScale = 1.0f;
                }
            }
            
        }
        else if (name == "EndMenu")
        {
            GameObject.FindGameObjectWithTag("Music").GetComponent<ScrMusicPlayer>().PlayLevelFinishSound();
            openEndMenu = true;
            PlayerPrefs.SetInt("Level" + (levelNumber + 1).ToString() + "Unlocked", 1);
            endMenu.SetActive(true);
            endMenu.GetComponent<ScrEndMenu>().finishTime.text = infoPanel.GetComponent<ScrInfoPanel>().timerValueText.text + " / " + infoPanel.GetComponent<ScrInfoPanel>().timerEndValueText.text;
            gameIsPaused = true;
            Time.timeScale = 0.0f;
        }
    }

    public void RestartScene()
    {
        if (Time.timeScale == 0.0f)
            Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadScene(string name)
    {
        if (Time.timeScale == 0.0f)
            Time.timeScale = 1.0f;
        SceneManager.LoadScene(name);
    }
}
