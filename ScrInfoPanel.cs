using UnityEngine;
using UnityEngine.UI;

public class ScrInfoPanel : MonoBehaviour
{
    public Sprite starSprite;
    public Sprite noStarSprite;
    public Image timerImage;
    public Text timerValueText;
    public Text timerSlash;
    public Text timerEndValueText;
    public Image star;
    float timerEndValue;
    float timerValue = 0.0f;
    int timerValueSeconds;
    int timerValueMinutes;
    int timerEndValueSeconds;
    int timerEndValueMinutes;
    public bool timeExpired = false;

    void Start()
    {
        timerEndValue = GameObject.FindGameObjectWithTag("Controller").GetComponent<ScrLevelController>().timerEndValue;
        timerEndValueSeconds = Mathf.FloorToInt(timerEndValue) % 60;
        timerEndValueMinutes = Mathf.FloorToInt(timerEndValue) / 60;
        if (timerEndValueSeconds < 10)
            timerEndValueText.text = timerEndValueMinutes.ToString() + ":0" + timerEndValueSeconds.ToString();
        else
            timerEndValueText.text = timerEndValueMinutes.ToString() + ":" + timerEndValueSeconds.ToString();
    }

    void Update()
    {
        timerValue += Time.deltaTime;
        if (timerValue > timerEndValue && !timeExpired)
        {
            timeExpired = true;
            timerValueText.color = Color.red;
        }
        timerValueSeconds = Mathf.FloorToInt(timerValue) % 60;
        timerValueMinutes = Mathf.FloorToInt(timerValue) / 60;

        if (timerValueSeconds < 10)
            timerValueText.text = timerValueMinutes.ToString() + ":0" + timerValueSeconds.ToString();
        else
            timerValueText.text = timerValueMinutes.ToString() + ":" + timerValueSeconds.ToString();
    }
}
