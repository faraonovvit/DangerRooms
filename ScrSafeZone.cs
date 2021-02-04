using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public enum Behaviour
{
    StartPoint = 0,
    EndPoint = 1,
    CheckPoint = 2
}

public class ScrSafeZone : MonoBehaviour
{
    public Sprite activeStateSprite;
    public Sprite normalStateSprite;
    [HideInInspector]
    public bool active;
    public Behaviour behaviour;
    public string endProperty;
    float timer;
    bool loadNextScene = false;

    private void Start()
    {
        if (behaviour == Behaviour.StartPoint)
            SetActive(true);
        else
            SetActive(false);
    }
    public void LoadNextScene(float time)
    {
        loadNextScene = true;
        timer = time;
    }

    private void Update()
    {
        if (loadNextScene)
        {
            timer -= Time.deltaTime;
            if (timer <= 0.0f)
            {
                //SceneManager.LoadScene(nextScene);
                PlayerPrefs.SetInt(endProperty, 1);
                if (GameObject.FindGameObjectWithTag("Controller").GetComponent<ScrLevelController>().infoPanel.GetComponent<ScrInfoPanel>().timeExpired)
                {
                    PlayerPrefs.SetInt("Level" + GameObject.FindGameObjectWithTag("Controller").GetComponent<ScrLevelController>().levelNumber.ToString() + "FinishInTimeStar", 0);
                }
                else
                {
                    PlayerPrefs.SetInt("Level" + GameObject.FindGameObjectWithTag("Controller").GetComponent<ScrLevelController>().levelNumber.ToString() + "FinishInTimeStar", 1);
                }
                GameObject.FindGameObjectWithTag("Controller").GetComponent<ScrLevelController>().ChangeStateMenu("EndMenu");
                loadNextScene = false;
            }
        }
    }

    public void SetActive(bool state)
    {
        active = state;
        if (state)
        {
            GetComponent<SpriteRenderer>().sprite = activeStateSprite;
            GameObject.FindGameObjectWithTag("Music").GetComponent<ScrMusicPlayer>().PlayCheckpointSound();
        }
        else
            GetComponent<SpriteRenderer>().sprite = normalStateSprite;
    }
}
