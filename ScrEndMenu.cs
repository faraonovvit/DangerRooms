using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrEndMenu : MonoBehaviour
{
    public Image finishStar;
    public Image finishInTimeStar;
    public Image findStar;
    public Text finishTime;
    public Sprite starSprite;
    public Sprite noStarSprite;
    public string levelName;

    private void OnEnable()
    {
        if (GameObject.FindGameObjectWithTag("Star") == null)
            PlayerPrefs.SetInt(levelName + "FindStar", 1);

        if (PlayerPrefs.GetInt(levelName + "FinishInTimeStar") == 1)
            finishInTimeStar.sprite = starSprite;
        else
            finishInTimeStar.sprite = noStarSprite;

        if (PlayerPrefs.GetInt(levelName + "FindStar") == 1)
            findStar.sprite = starSprite;
        else
            findStar.sprite = noStarSprite;
    }
}
