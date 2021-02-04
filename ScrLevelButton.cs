using UnityEngine;
using UnityEngine.UI;

public class ScrLevelButton : MonoBehaviour
{
    Button button;
    public Text text;
    public Image finishStar;
    public Image finishInTimeStar;
    public Image findStar;
    public Sprite starSprite;
    public Sprite noStarSprite;

    void Awake()
    {
        button = GetComponent<Button>();
        if (PlayerPrefs.GetInt("Level" + text.text + "FinishStar") == 1)
            finishStar.sprite = starSprite;
        else
            finishStar.sprite = noStarSprite;

        if (PlayerPrefs.GetInt("Level" + text.text + "FinishInTimeStar") == 1)
            finishInTimeStar.sprite = starSprite;
        else
            finishInTimeStar.sprite = noStarSprite;

        if (PlayerPrefs.GetInt("Level" + text.text + "FindStar") == 1)
            findStar.sprite = starSprite;
        else
            findStar.sprite = noStarSprite;
    }

    public void ChangeState(bool state)
    {
        button.interactable = state;
        GetComponent<BoxCollider2D>().isTrigger = !state;
    }
}
